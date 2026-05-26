namespace Practical25.Application.Features.Employees.Commands;

public record CreateEmployeeCommand(
    string Name, 
    decimal Salary,
    int DepartmentId,
    string EmailId
) : IRequest<EmployeeResponse>;