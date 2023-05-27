using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class ApplicationUser : IdentityUser, IAuditEntity
    {
        public ApplicationUser()
        {
           // MarketersReservations = new HashSet<MarketersReservations>();
        }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public long MembershipNo { get; set; }
        public int? IdNumber { get; set; }
        public UserType UserType { get; set; }
        public string? ImageUser { get; set; }
        public string? Otp { get; set; }

        [ForeignKey("CreatedBy")]
        public string? CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time")) :
            TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Asia/Riyadh")); //DateTime.UtcNow;
        [ForeignKey("ModifiedBy")]
        public string? ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }

        //[ForeignKey("PlatformPercentage")]
        //public int? PlatformPercentageId { get; set; }
      //  public PlatformPercentage? PlatformPercentage { get; set; }

       // public ICollection<MarketersReservations> MarketersReservations { get; set; }

    }
}