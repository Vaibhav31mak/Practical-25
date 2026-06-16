namespace Practical25.Application.Features.Employees.Queries;

public sealed record GetAllEmployeesQuery()
    : IRequest<IReadOnlyList<EmployeeResponse>>;
