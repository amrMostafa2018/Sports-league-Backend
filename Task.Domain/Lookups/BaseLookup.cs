
using Task.Domain.Base;

namespace Task.Domain.Lookups
{
    public abstract class BaseLookup : BaseEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
