namespace Practical25.Application.Features.Employees.Queries;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponse>;
