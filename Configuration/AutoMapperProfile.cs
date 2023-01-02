using AutoMapper;
using Mi_Granjita_Paraiso.DTOs;
using Mi_Granjita_Paraiso.DTOs.Item;
using Microsoft.AspNetCore.Identity;

namespace Mi_Granjita_Paraiso.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUser, IdentityUser>();
            CreateMap<Entities.File, FileCreatedDTO>();
            CreateMap<Entities.Item, ItemDTOStandard>()
                .ForMember(x => x.PicturePath, x => x.MapFrom(y => y.ItemFiles.FirstOrDefault().File))
                .ForMember(x => x.Status, x => x.MapFrom(y => y.Status.Name))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name));
            CreateMap<ItemDTOStandard, Entities.Item>();
        }
    }
}
