using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Areas.Admin.Models
{
    public class SongForeignClearUrlHelper
    {
        private SongViewModel songForeign;

        public SongForeignClearUrlHelper(SongViewModel songForeign)
        {
            this.songForeign = songForeign;
        }

        public bool HasArtist
        {
            get
            {
                return songForeign.ArtistId.HasValue;
            }
        }

        public string ArtistIdUrl
        {
            get
            {
                string result = "";
                if (HasArtist)
                {
                    if (!string.IsNullOrEmpty(songForeign.ArtistClearUrlName))
                    {
                        result = songForeign.ArtistClearUrlName;
                    }
                    else
                    {
                        result = songForeign.ArtistId.ToString();
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
                
                if (!string.IsNullOrEmpty(songForeign.ClearUrlName))
                {
                    result = songForeign.ClearUrlName;
                }
                else
                {
                    result = songForeign.Id.ToString();
                }
                
                return result;
            }
            
        }


    }
}