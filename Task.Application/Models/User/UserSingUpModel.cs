using System.ComponentModel.DataAnnotations;
using Task.Domain.Enums;

namespace Task.Application.Models.User
{
    public class UserSingUpModel
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public int? IdNumber { get; set; }
        [Required]
        public UserType UserType { get; set; }

    }
}
