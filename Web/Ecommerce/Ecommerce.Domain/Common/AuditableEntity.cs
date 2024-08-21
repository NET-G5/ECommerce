namespace Ecommerce.Domain.Common;

public class AuditableEntity : EntityBase
{
    public DateTime CreatedAt { get; set; }

    protected AuditableEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
