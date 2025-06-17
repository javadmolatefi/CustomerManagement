using CustomerManagement.Application.Customers;
using CustomerManagement.Application.Customers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerFacade _facade;

    public CustomerController(ICustomerFacade facade)
        => _facade = facade;

    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetAll()
    {
        var list = await _facade.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto?>> Get(int id)
    {
        var customer = await _facade.GetByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CustomerDto dto)
    {
        var id = await _facade.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = id }, id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CustomerDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _facade.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _facade.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("export")]
    public async Task<IActionResult> ExportCustomers()
    {
        var customers = await _facade.GetAllAsync();

        var sb = new StringBuilder();
        sb.AppendLine("Id\tName\tAddress\tCityTitle\tPhone\tFax\tCoworkers");

        foreach (var c in customers)
        {
            sb.AppendLine($"{c.Id}\t{c.Name}\t{c.Address}\t{c.CityTitle}\t{c.Phone}\t{c.Fax}\t{c.Coworkers}");
        }

        var fileBytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(fileBytes, "text/plain", "customers.txt");
    }
}
