using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Application.Models.Common;
using Task.Domain.Entites;
using Task.Domain.Enums;

namespace Task.Application.Models.Contracts.Add
{
    public class AddContractUploadFile : IMapFrom<ContractAttachment>
    {
        public int ContractId { get; set; }
        public string FilePath { get; set; }
        public ContractAttachmentType AttachmentType { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractAttachment, AddContractUploadFile>().ForMember(d => d.FilePath, opt => opt.MapFrom(s => s.AttachmentUrl)).ReverseMap();
            profile.CreateMap< UploadFileResponse, AddContractUploadFile >().ReverseMap();

        }
    }
}
