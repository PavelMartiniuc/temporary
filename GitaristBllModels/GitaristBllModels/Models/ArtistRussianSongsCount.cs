using Gitarist.Domain;

namespace Gitarist.Bll.Models
{
    public class ArtistForeignSongsCount
    {
        public ArtistForeign Artist
        {
            get;
            set;
        }

        public long SongCount
        {
            get;
            set;
        }
    }
}
