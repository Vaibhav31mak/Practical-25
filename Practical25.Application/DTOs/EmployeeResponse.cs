
namespace Practical25.Application.DTOs;

public record EmployeeResponse(
    int Id,
    string Name,
    decimal Salary,
    int DepartmentId,
    string EmailId,
    DateTime JoiningDate,
    bool Status
);
