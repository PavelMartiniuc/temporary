using Gitarist.Domain;

namespace Gitarist.Bll.Models
{
    public class SongsByThemesModel
    {
        public Theme Theme
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
