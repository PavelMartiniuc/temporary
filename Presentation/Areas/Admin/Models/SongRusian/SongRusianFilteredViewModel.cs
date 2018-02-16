using Gitarist.Areas.Admin.Models.Lookup;
using Gitarist.Domain;
using Gitarist.Models.Lookup;
using System.Collections.Generic;

namespace Gitarist.Areas.Admin.Models
{
    public class SongRusianFilteredViewModel
    {
        public List<SongRusianViewModel> Songs { get; set; }

        public long? ArtistId { get; set; }
        public long? ThemeId { get; set; }

        public List<LookupItem> Artists
        {
            get
            {
                return new Lookup<ArtistRussian>(true, true).GetItems();
            }
        }

        public List<LookupItem> Themes
        {
            get
            {
                return new Lookup<Theme>(true, true).GetItems();
            }
        }
    }
}