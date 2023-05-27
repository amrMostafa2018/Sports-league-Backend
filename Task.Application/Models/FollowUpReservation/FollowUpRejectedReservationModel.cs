using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;

namespace Task.Application.Models.FollowUpReservation
{
    public class FollowUpRejectedReservationModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int Id { get; set; }
        public int ReservationNumber { get; set; }
        public int ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public string ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, FollowUpRejectedReservationModel>()
                                                .ForMember(d => d.ContractNumber, opt => opt.MapFrom(s => s.Contract.ContractNumber))
                                                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FullName))
                                                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.Contract.ImageUrl) ? HostUrl.BackEnd(s.Contract.ImageUrl) : s.Contract.ImageUrl))
                                                .ReverseMap();
        }
    }
}
