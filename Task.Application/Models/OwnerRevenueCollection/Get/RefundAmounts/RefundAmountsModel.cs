using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.OwnerRevenueCollection.Get.RefundAmounts
{
    public class RefundAmountsModel : IMapFrom<Domain.Entites.Reservations>
    {
        public int ReservationNumber { get; set; }
        public int ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
        public decimal TotalAmount { get; set; } // المبلغ الاجمالى
        public decimal OwnerAmountDue { get; set; } // المبلغ المستحق للمالك
        public decimal CustomerAmountDue { get; set; } // المبلغ المستحق للعميل
        public decimal RevenueAmount { get; set; } // نسبة المنصه
        public decimal ActualAmount { get; set; } // النسبة الفعلية
        public DateTime RefundedDate { get; set; }
        public ContractReservationStatus Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Reservations, RefundAmountsModel>()
                   .ForMember(d => d.ContractNumber, opt => opt.MapFrom(s => s.Contract.ContractNumber))

                   .ForMember(d => d.TotalAmount, opt => opt.MapFrom(s => s.Contract.ContractPayment.InitialReservationPayment))
                   .ForMember(d => d.RefundedDate, opt => opt.MapFrom(s => s.ReservationPayment.CreationDate)).ReverseMap();
        }
    }
}
