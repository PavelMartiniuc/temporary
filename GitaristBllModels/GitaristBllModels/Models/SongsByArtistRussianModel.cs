using Gitarist.Domain;

namespace Gitarist.Bll.Models
{
    public class SongsByArtistRussianModel
    {
        public ArtistRussian Artist
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
