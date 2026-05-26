namespace Practical25.Application.Features.Employees.Handlers;

public class DeleteEmployeeHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    /// <summary>
    /// Handles the request to delete an employee.
    /// </summary>
    public async Task<bool> Handle(DeleteEmployeeCommand request
        , CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            return false; 
        }

        _unitOfWork.Employees.Remove(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
