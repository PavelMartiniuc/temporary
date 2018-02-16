using AutoMapper;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Theme;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.AutoMapperProfiles
{
    public class ThemesProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Theme, ThemeViewModel>();
            CreateMap<SongsByThemesModel, ThemeSongCount>();
        }
    }
}