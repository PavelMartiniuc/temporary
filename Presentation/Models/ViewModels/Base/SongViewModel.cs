using System;

namespace Gitarist.Models.ViewModels.Base
{
    public class SongViewModel
    {
        public long Id { get; set; }
        public long? ArtistId { get; set; }
        public long? ThemeId { get; set; }
        public bool IsNew { get; set; }
        public string Name { get; set; }
        public string Chords { get; set; }
        public bool Deleted { get; set; }
        public bool IsPopular { get; set; }
        public DateTime Datecreate { get; set; }
        public string ClearUrlName { get; set; }


        public string ArtistName { get; set; }
        public string ThemeName { get; set; }
        public string ArtistClearUrlName { get; set; }
    }
}