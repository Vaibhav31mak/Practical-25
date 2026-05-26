namespace Practical25.Application.Features.Employees.Validators;

public class CreateEmployeeValidator
    : AbstractValidator<CreateEmployeeCommand>
{
    /// <summary>
    /// Initializes validation rules for creating an employee.
    /// </summary>
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Salary)
            .GreaterThan(0);

        RuleFor(x => x.EmailId)
            .EmailAddress();

        RuleFor(x => x.DepartmentId)
            .InclusiveBetween(1, 5);
    }
}
