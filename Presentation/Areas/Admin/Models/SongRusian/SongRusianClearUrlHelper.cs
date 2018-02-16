using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Areas.Admin.Models
{
    public class SongRusianClearUrlHelper
    {
        private SongViewModel songRusian;

        public SongRusianClearUrlHelper(SongViewModel songRusian)
        {
            this.songRusian = songRusian;
        }

        public bool HasArtist
        {
            get
            {
                return songRusian.ArtistId.HasValue;
            }
        }

        public string ArtistIdUrl
        {
            get
            {
                string result = "";
                if (HasArtist)
                {
                    if (!string.IsNullOrEmpty(songRusian.ArtistClearUrlName))
                    {
                        result = songRusian.ArtistClearUrlName;
                    }
                    else
                    {
                        result = songRusian.ArtistId.ToString();
                    }
                }

                return result;
            }
            
        }


        public string SongIdUrl
        {
            get
            {
                string result = "";
                
                if (!string.IsNullOrEmpty(songRusian.ClearUrlName))
                {
                    result = songRusian.ClearUrlName;
                }
                else
                {
                    result = songRusian.Id.ToString();
                }
                
                return result;
            }
            
        }


    }
}