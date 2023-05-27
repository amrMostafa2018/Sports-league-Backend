using System.ComponentModel.DataAnnotations;
namespace Nafes.Domain.Interfaces
{
    public interface ILookup
    {
        [MaxLength(500)]
        string NameAr { get; set; }
        [MaxLength(500)]
        string NameEn { get; set; }
        bool IsDeleted { get; set; }
        bool IsVisible { get; set; }
        int? MappedId { get; set; }
    }
}
