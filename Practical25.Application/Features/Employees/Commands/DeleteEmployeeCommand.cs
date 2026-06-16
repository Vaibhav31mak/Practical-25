namespace Practical25.Application.Features.Employees.Commands;

public record DeleteEmployeeCommand(int Id)
    : IRequest<bool>;