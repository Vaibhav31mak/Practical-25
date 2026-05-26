namespace Practical25.Application.Features.Employees.Validators;

public class UpdateEmployeeValidator
    : AbstractValidator<UpdateEmployeeCommand>
{
    /// <summary>
    /// Initializes validation rules for updating an employee.
    /// </summary>
    public UpdateEmployeeValidator()
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
        RuleFor(x => x.Id)
            .GreaterThan(0);
        RuleFor(x => x.Status)
            .NotNull();
    }
}
