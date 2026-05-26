namespace Practical25.Application.Features.Employees.Handlers;

public class UpdateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper) 
    : IRequestHandler<UpdateEmployeeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<int> Handle(UpdateEmployeeCommand request
        , CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            return 0; 
        }
        _mapper.Map(request, employee);

        _unitOfWork.Employees.Update(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
