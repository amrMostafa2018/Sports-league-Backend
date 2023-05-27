using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;
using Task.Shared.Enums;

namespace Task.Application.Models.FollowUpReservation
{
    public class TopPaymentMethodsResponse
    {
        public bool IsCash { get; set; }
        public int Count { get; set; }
    }
}
