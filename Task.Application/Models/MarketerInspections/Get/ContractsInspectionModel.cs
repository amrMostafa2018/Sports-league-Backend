using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Core.Domains;
using Task.Domain.Enums;

namespace Task.Application.Models.MarketerInspections.Get
{
    public class ContractsInspectionModel : IMapFrom<Domain.Entites.ContractsInspectionRequest>
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public ContractType ContractType { get; set; }
        public int? BlockNumber { get; set; }
        public int? BuildingNumber { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CustomerName { get; set; }
        public ContractsInspectionRequestStatus Status { get; set; }
        public string ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.ContractsInspectionRequest, ContractsInspectionModel>()
                   .ForMember(d => d.ContractType, opt => opt.MapFrom(s => s.Contract.ContractType))
                   .ForMember(d => d.ContractId, opt => opt.MapFrom(s => s.Contract.Id))
                   .ForMember(d => d.BlockNumber, opt => opt.MapFrom(s => s.Contract.BlockNumber))
                   .ForMember(d => d.BuildingNumber, opt => opt.MapFrom(s => s.Contract.BuildingNumber))
                   .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Contract.Address))
                   .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.CreatedBy.FullName))
                   .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.Contract.City.NameAr))
                   .ForMember(d => d.RegionName, opt => opt.MapFrom(s => s.Contract.Region.NameAr))
                   .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => !string.IsNullOrEmpty(s.Contract.ImageUrl) ? HostUrl.BackEnd(s.Contract.ImageUrl) : s.Contract.ImageUrl));
        }
    }
}