using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.OwnerContractRequests.GetById
{
    public class MarketerReservationModel : IMapFrom<Domain.Entites.MarketersReservations>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.MarketersReservations, MarketerReservationModel>()
                   .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.Marketer.FullName))
                   .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Marketer.PhoneNumber));
        }
    }
}
