using Gitarist.Areas.Admin.Models.Lookup;
using Gitarist.Domain;
using Gitarist.Models.Lookup;
using System.Collections.Generic;

namespace Gitarist.Areas.Admin.Models
{
    public class SongForeignFilteredViewModel
    {
        public List<SongForeignViewModel> Songs { get; set; }

        public long ArtistId { get; set; }
        public long ThemeId { get; set; }


        public List<LookupItem> Artists
        {
            get
            {
                return new Lookup<ArtistForeign>(true, true).GetItems();
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