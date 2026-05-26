namespace Practical25.Application.Features.Employees.Commands;

public record UpdateEmployeeCommand(
    int Id,
    string Name,
    decimal Salary,
    int DepartmentId,
    string EmailId,
    bool Status
) : IRequest<int>;
    