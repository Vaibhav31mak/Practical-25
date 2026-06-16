namespace Practical25.Domain.Entities;

public sealed class Employee : IStatusCheck
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public required string EmailId { get; set; }
    public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
    public bool Status { get; set; } = true;
}
