namespace Gitarist.Models.ViewModels.Base
{
    public class ThemeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public string ClearUrlName { get; set; }
    }
}