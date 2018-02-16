using System.Collections.Generic;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels
{
    public class StartPage
    {
        public List<SongViewModel> LastRuSongs { get; set; }
        public List<ArtistViewModel> PopularRuArtists { get; set; }
        public List<SongViewModel> PopularRuSongs { get; set; }

        public List<SongViewModel> LastEngSongs { get; set; }
        public List<ArtistViewModel> PopularEngArtists { get; set; }
        public List<SongViewModel> PopularEngSongs { get; set; }
    }
}