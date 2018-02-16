using System.Collections.Generic;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels.ArtistForeign
{
    public class ArtistsForeignByLetter
    {
        public string Letter { get; set; }
        public int SongsCount { get; set; }
        public List<ArtistForeignCount> Artists { get; set; }
        public List<SongViewModel> ArtistLessSongs { get; set; }
    }
}