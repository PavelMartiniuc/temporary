using System.Collections.Generic;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels.ArtistRusian
{
    public class ArtistsRusianByLetter
    {
        public string Letter { get; set; }
        public int SongsCount { get; set; }
        public List<ArtistRussianCount> Artists { get; set; }
        public List<SongViewModel> ArtistlessSongs { get; set; }
    }
}