using CustomerManagement.Application.Cities;
using CustomerManagement.Application.Cities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CityController : ControllerBase
{
    private readonly ICityFacade _facade;

    public CityController(ICityFacade facade)
        => _facade = facade;

    [HttpGet]
    public async Task<ActionResult<List<CityDto>>> GetAll()
    {
        return Ok(await _facade.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CityDto?>> Get(int id)
    {
        var city = await _facade.GetByIdAsync(id);
        if (city == null) return NotFound();
        return Ok(city);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CityDto dto)
    {
        var id = await _facade.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CityDto dto)
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
    public async Task<IActionResult> ExportCities()
    {
        var cities = await _facade.GetAllAsync();

        var sb = new StringBuilder();
        sb.AppendLine("Id\tTitle");

        foreach (var city in cities)
        {
            sb.AppendLine($"{city.Id}\t{city.Title}");
        }

        var fileBytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(fileBytes, "text/plain", "cities.txt");
    }
}
