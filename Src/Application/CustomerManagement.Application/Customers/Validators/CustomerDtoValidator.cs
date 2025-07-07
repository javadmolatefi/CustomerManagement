using CustomerManagement.Application.Customers.Dtos;
using FluentValidation;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100);

        RuleFor(c => c.CityId)
            .GreaterThan(0).WithMessage("Please select a valid city.");

        RuleFor(c => c.Address)
            .MaximumLength(250);

        RuleFor(c => c.Phone)
            .Matches(@"^\+?\d{10,15}$")
            .When(c => !string.IsNullOrWhiteSpace(c.Phone))
            .WithMessage("Phone number is not valid.");
    }
}
