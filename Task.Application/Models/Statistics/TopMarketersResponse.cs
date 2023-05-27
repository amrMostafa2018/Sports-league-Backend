using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Entites;

namespace Task.Application.Models.FollowUpReservation
{
    public class TopMarketersResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CustomerCount { get; set; }
        public DateTime? LastReservationDate { get; set; }
    }
}
