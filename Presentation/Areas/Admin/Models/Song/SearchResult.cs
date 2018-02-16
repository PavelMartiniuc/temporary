using System.Collections.Generic;

namespace Gitarist.Areas.Admin.Models.Song
{
    public class SearchResult
    {
        public string Criteria { get; set; }

        public List<SongRusianViewModel> ruSongs { get; set; }

        public List<SongForeignViewModel> engSongs { get; set; }
    }

}