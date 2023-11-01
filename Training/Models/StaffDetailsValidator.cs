using FluentValidation;
using Training.Models;

public class StaffDetailsValidator : AbstractValidator<Staff_details>
{
    public StaffDetailsValidator()
    {
        RuleFor(staff => staff.Staff_name)
            .NotEmpty()
            .Matches(@"^[a-zA-Z]+$")
            .WithMessage("Staff name is required.");

        RuleFor(staff => staff.Staff_salary)
            .GreaterThan(0)
            .WithMessage("Salary must be greater than 0.");

        RuleFor(staff => staff.Staff_native)
            .NotEmpty()
            .Matches(@"^[a-zA-Z]+$")
            .WithMessage("Native is required.");

        RuleFor(staff => staff.Staff_contact)
            .NotEmpty()
            .WithMessage("Contact is required.")
            .Matches(@"^\d{10}$") 
            .WithMessage("Contact must be a 10-digit number.");
    }
}
    