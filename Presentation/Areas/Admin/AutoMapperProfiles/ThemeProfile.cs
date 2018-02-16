using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Domain;

namespace Gitarist.Areas.Admin.AutoMapperProfiles
{
    public class ThemeProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Theme, ThemeViewModel>();

            CreateMap<ThemeViewModel, Theme>();
        }
    }
}