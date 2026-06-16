namespace Practical25.Domain.AuditContracts;

// Status check interface for soft delete.
public interface IStatusCheck
{
    bool Status { get; set; }
}
