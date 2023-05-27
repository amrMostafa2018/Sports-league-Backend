using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;

namespace Task.Application.Models.AdminContract.Get
{
    public class AdminContractModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
        public bool? IsApproved { get; set; }
        public ContractStatus Status { get; set; }
        public int InitialReservationExpirationDate { get; set; }
        public DateTime ReservationCreationDate { get; set; }
        public string ImageUrl { get; set; }
        public string OwnerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, AdminContractModel>()
                .ForMember(d => d.InitialReservationExpirationDate, opt => opt.MapFrom(s => s.ContractPayment.InitialReservationExpirationDate))
                .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr))
                .ForMember(d => d.ReservationCreationDate, opt => opt.MapFrom(s => s.Reservations.FirstOrDefault().CreationDate))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.ImageUrl) ? HostUrl.BackEnd(s.ImageUrl) : s.ImageUrl));

        }
    }
}
