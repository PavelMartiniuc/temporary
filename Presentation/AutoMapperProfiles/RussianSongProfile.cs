using AutoMapper;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.AutoMapperProfiles
{
    public class RussianSongProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SongRussian, SongViewModel>()
                .ForMember(x => x.ArtistId, y => y.MapFrom(z => z.ArtistRussian.Id))
                .ForMember(x => x.ThemeId, y => y.MapFrom(z => z.Theme.Id))
                .ForMember(x => x.ThemeName, y => y.MapFrom(z => z.Theme.Name))
                .ForMember(x => x.ArtistName, y => y.MapFrom(z => z.ArtistRussian.Name))
                .ForMember(x => x.ArtistClearUrlName, y => y.MapFrom(z => z.ArtistRussian.ClearUrlName));
        }
    }
}