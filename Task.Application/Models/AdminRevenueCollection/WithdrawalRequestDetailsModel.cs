
using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.AdminRevenueCollection
{
    public class WithdrawalRequestDetailsModel : IMapFrom<Domain.Entites.RevenueCollection>
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RevenueAmount { get; set; }
        public List<WithdrawableReservationsModel> withdrawableReservations { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.RevenueCollection, WithdrawalRequestDetailsModel>()
                  // .ForMember(d => d.withdrawableReservations, opt => opt.MapFrom(s =>s.ReservationPayments))
                   .ReverseMap();
            
        }
    }
}
