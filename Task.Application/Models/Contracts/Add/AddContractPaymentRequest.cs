using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.Contracts.Add
{
    public class AddContractPaymentRequest : IMapFrom<Domain.Entites.ContractPayment>
    {
        public decimal InitialReservationPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MarkterAmount { get; set; }
        public int InitialReservationExpirationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ContractPayment, AddContractPaymentRequest>().ReverseMap();
        }
    }
}