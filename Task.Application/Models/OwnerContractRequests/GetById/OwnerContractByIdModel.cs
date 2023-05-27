using AutoMapper;
using Task.Application.Common.Mappings;

namespace Task.Application.Models.OwnerContractRequests.GetById
{
    public class OwnerContractByIdModel : IMapFrom<Domain.Entites.Contracts>
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public string Address { get; set; }
        public string PlannedName { get; set; }
        public string CityName { get; set; }
        public int BlockNumber { get; set; }
        public int BuildingNumber { get; set; }
        public bool? IsApproved { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.Contracts, OwnerContractByIdModel>()
                   .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.NameAr)).ReverseMap();

        }
    }
}
