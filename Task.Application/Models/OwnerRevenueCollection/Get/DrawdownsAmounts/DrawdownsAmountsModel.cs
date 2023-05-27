using AutoMapper;
using Task.Application.Common.Mappings;


namespace Task.Application.Models.OwnerRevenueCollection.Get.DrawdownsAmounts
{
    public class DrawdownsAmountsModel : IMapFrom<Domain.Entites.RevenueCollection>
    {
        public long RequestNo { get; set; }
        public string Iban { get; set; }
        public decimal ActualAmount { get; set; } // النسبة الفعلية
        public DateTime TransferDate { get; set; }
        public int ReservationCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.RevenueCollection, DrawdownsAmountsModel>()
                   .ForMember(d => d.TransferDate, opt => opt.MapFrom(s => s.CreationDate))
                   .ForMember(d => d.ReservationCount, opt => opt.MapFrom(s => s.ReservationsRevenue.Count))
                   .ForMember(d => d.ActualAmount, opt => opt.MapFrom(s => s.OwnerAmountDue))
                   .ReverseMap();
        }
    }
}
