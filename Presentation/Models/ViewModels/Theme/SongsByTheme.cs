using System.Collections.Generic;
using Gitarist.Models.ViewModels.Base;

namespace Gitarist.Models.ViewModels
{
    public class SongsByTheme
    {
        public List<SongViewModel> Songs { get; set; }
        public ThemeViewModel Theme { get; set; }
    }
}