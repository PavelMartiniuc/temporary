using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Domain;


namespace Gitarist.Areas.Admin.AutoMapperProfiles
{
    public class ArtistRussianProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ArtistRussian, ArtistRusianViewModel>();

            CreateMap<ArtistRusianViewModel, ArtistRussian>()
                .ForMember(x=> x.SongRussians, y => y.Ignore());
        }
    }
}