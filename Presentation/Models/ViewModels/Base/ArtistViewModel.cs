namespace Gitarist.Models.ViewModels.Base
{
    public class ArtistViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public bool IsPopular { get; set; }
        public bool Deleted { get; set; }

        public string ClearUrlName { get; set; }
    }
}