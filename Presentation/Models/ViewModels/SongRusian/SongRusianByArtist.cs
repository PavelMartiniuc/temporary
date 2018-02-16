using System.Collections.Generic;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels
{
    public class SongRusianByArtist
    {
        public ArtistViewModel Artist { get; set; }

        public List<SongViewModel> ArtistSongs { get; set; }
   
    }
}