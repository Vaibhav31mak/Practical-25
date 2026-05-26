namespace Practical25.Application.Features.Employees.Handlers;

public class GetAllEmployeesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<EmployeeResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the request to retrieve all employees.
    /// </summary>
    public async Task<IReadOnlyList<EmployeeResponse>> Handle(GetAllEmployeesQuery request
        , CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.Employees.GetAllAsync(cancellationToken);

        return _mapper.Map<IReadOnlyList<EmployeeResponse>>(employees);
    }
}
