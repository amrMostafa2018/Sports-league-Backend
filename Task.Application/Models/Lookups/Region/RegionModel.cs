using AutoMapper;
using Task.Application.Common.Mappings;


namespace Task.Application.Models.Lookups.City.Get
{
    public class RegionModel : IMapFrom<Domain.Lookups.Region>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Lookups.Region, RegionModel>().ReverseMap();
        }
    }
}
