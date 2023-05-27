using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;
using Task.Shared.Enums;

namespace Task.Application.Models.FollowUpReservation
{
    public class TopVisitedCitiesResponse
    {
        public int? CityId  { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int Count { get; set; }
    }
}
