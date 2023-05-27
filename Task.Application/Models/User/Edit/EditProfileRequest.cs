using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.User.Edit
{
    public class EditProfileRequest 
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUser { get; set; }
        public string Otp { get; set; }
        public int? IdNumber { get; set; }
    }
}
