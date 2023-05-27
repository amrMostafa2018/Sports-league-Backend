using System.ComponentModel.DataAnnotations.Schema;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class PlatformPercentage : BaseEntity<int>
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public decimal Percentage { get; set; }
        public UserType UserType { get; set; }
    }
}
