using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels.Artist
{
    public class PopularArtistCount
    {
        public ArtistViewModel Artist { get; set; }
        public long SongsCount { get; set; }
    }
}