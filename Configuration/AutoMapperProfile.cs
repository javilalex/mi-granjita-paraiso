using AutoMapper;
using Mi_Granjita_Paraiso.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Mi_Granjita_Paraiso.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUser, IdentityUser>();
            CreateMap<Entities.File, FileCreatedDTO>();
        }
    }
}
