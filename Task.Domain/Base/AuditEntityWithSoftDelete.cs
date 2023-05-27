using Task.Data.Repository;
using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public class AuditEntityWithSoftDelete<T> : AuditEntity<T>, ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
