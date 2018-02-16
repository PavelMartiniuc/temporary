using Gitarist.Domain;

namespace Gitarist.Bll.Models
{
    public class SongsByArtistForeignModel
    {
        public ArtistForeign Artist
        {
            get;
            set;
        }

        public long SongsCount
        {
            get;
            set;
        }
    }
}
