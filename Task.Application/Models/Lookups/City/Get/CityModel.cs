using AutoMapper;
using Task.Application.Common.Mappings;


namespace Task.Application.Models.Lookups.City.Get
{
    public class CityModel : IMapFrom<Domain.Lookups.City>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? RegionId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Lookups.City, CityModel>().ReverseMap();
        }
    }
}
