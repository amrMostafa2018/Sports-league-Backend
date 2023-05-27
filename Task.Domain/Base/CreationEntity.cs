using System.Runtime.InteropServices;
using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public class CreationEntity<T> : BaseEntity<T>
    {
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time")) :
            TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Asia/Riyadh")); //DateTime.UtcNow;
    }
}