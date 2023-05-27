using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class ContractAttachment : BaseEntity<int>
    {
        public ContractAttachmentType AttachmentType { get; set; }
        public string AttachmentUrl { get; set; }

        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }

    }
}