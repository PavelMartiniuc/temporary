using AutoMapper;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.AutoMapperProfiles
{
    public class SongForeignProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SongForeign, SongViewModel>()
                .ForMember(x => x.ArtistId, y => y.MapFrom(z => z.ArtistForeign.Id))
                .ForMember(x => x.ThemeId, y => y.MapFrom(z => z.Theme.Id))
                .ForMember(x => x.ThemeName, y => y.MapFrom(z => z.Theme.Name))
                .ForMember(x => x.ArtistName, y => y.MapFrom(z => z.ArtistForeign.Name))
                .ForMember(x => x.ArtistClearUrlName, y => y.MapFrom(z => z.ArtistForeign.ClearUrlName));
        }
    }
}