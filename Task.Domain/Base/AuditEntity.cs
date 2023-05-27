using System.Runtime.InteropServices;
using Task.Data.Repository;
using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public class AuditEntity<T> :  BaseEntity<T> , IAuditEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? ModificationDate { get; set; }

    }
}
