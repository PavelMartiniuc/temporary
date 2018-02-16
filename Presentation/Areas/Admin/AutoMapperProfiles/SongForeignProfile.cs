using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Bll.Models;
using Gitarist.Domain;

namespace Gitarist.Areas.Admin.AutoMapperProfiles
{
    public class SongForeignProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SongForeign, SongForeignViewModel>()
                .ForMember(x => x.artistId, y => y.MapFrom(z => z.ArtistForeign.Id))
                .ForMember(x => x.themeId, y => y.MapFrom(z => z.Theme.Id))
                .ForMember(x => x.ThemeName, y => y.MapFrom(z => z.Theme.Name))
                .ForMember(x => x.ArtistName, y => y.MapFrom(z => z.ArtistForeign.Name))
                .ForMember(x => x.Artists, y => y.Ignore())
                .ForMember(x => x.Themes, y => y.Ignore())
                .ForMember(x => x.ChordKeys, y => y.Ignore());
            CreateMap<SongForeignViewModel, EditSongModel>();
        }
    }
}