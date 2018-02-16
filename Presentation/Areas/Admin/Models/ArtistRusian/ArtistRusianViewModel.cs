using Gitarist.Areas.Admin.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.Models
{
    public class ArtistRusianViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Наименование русского исполнителя обязательно")]
        [ArtistRussianUniqueName(ErrorMessage = "Русский исполнитель с таким именем уже существует")]
        public string name { get; set; }
        public string biography { get; set; }
        public bool deleted { get; set; }
        [Required]
        public bool isPopular { get; set; }

        [ArtistRussianClearUrlUnique(ErrorMessage="Русский исполнитель с таким Чпу уже существует")]
        public string clearUrlName { get; set; }

    }
}