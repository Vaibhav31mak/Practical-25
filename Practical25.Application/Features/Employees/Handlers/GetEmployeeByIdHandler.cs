namespace Practical25.Application.Features.Employees.Handlers;

public class GetEmployeeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the request to retrieve an employee by identifier.
    /// </summary>
    public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<EmployeeResponse>(employee);
    }
}