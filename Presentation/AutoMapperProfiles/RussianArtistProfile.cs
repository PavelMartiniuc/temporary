using AutoMapper;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Artist;
using Gitarist.Models.ViewModels.ArtistRusian;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.AutoMapperProfiles
{
    public class ArtistRussianProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ArtistRussian, ArtistViewModel>();

            CreateMap<ArtistRussianSongsCount, ArtistRussianCount>();

            CreateMap<SongsByArtistRussianModel, PopularArtistCount>()
                .ForMember(x => x.Artist, y => y.MapFrom(z => z.Artist));
        }
    }
}