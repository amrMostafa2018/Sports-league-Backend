using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public interface IAuditEntity
    {
        public DateTime CreationDate { get; set; } 
        public DateTime? ModificationDate { get; set; }
    }
}
