namespace Gitarist.Bll.Models
{
    public class EditSongModel
    {
        public long id { get; set; }
        public long? artistId { get; set; }
        public long? themeId { get; set; }
        public bool isNew { get; set; }
        public bool isPopular { get; set; }

        public string clearUrlName { get; set; }

        public string name { get; set; }

        public string chords { get; set; }
        
    }
}
