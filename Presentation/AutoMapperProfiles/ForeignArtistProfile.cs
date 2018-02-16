using AutoMapper;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Artist;
using Gitarist.Models.ViewModels.ArtistForeign;
using Gitarist.Models.ViewModels.Base;


namespace Gitarist.AutoMapperProfiles
{
    public class ArtistForeignProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ArtistForeign, ArtistViewModel>();

            CreateMap<ArtistForeignSongsCount, ArtistForeignCount>();

            CreateMap<SongsByArtistForeignModel, PopularArtistCount>()
                .ForMember(x => x.Artist, y => y.MapFrom(z => z.Artist));
        }
    }
}