using Gitarist.Areas.Admin.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.Models
{
    public class ArtistForeignViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Наименование зарубежного исполнителя обязательно")]
        [ArtistForeignUniqueName(ErrorMessage = "Зарубежный исполнитель с таким именем уже существует")]
        public string name { get; set; }
        public string biography { get; set; }
        public bool deleted { get; set; }
        [Required]
        public bool isPopular { get; set; }
        
        [ArtistForeignClearUrlUnique(ErrorMessage = "Зарубежный исполнитель с таким Чпу уже существует")]
        public string clearUrlName { get; set; }
    }
}