namespace Practical25.Application.Features.Employees.Handlers;

public class CreateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<int> Handle(CreateEmployeeCommand request
        , CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);

        await _unitOfWork.Employees.AddAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
