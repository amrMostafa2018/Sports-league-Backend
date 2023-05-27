using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.MarketerReservations.Add
{
    public class AddCustomerDataRequest : IMapFrom<Domain.Entites.ApplicationUser>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int IdNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ApplicationUser, AddCustomerDataRequest>().ReverseMap();
        }
    }
}
