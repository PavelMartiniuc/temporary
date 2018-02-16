using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Domain;


namespace Gitarist.Areas.Admin.AutoMapperProfiles
{
    public class ArtistForeignProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ArtistForeign, ArtistForeignViewModel>();

            CreateMap<ArtistForeignViewModel, ArtistForeign>()
                .ForMember(x=> x.SongsForeign, y => y.Ignore());
        }
    }
}