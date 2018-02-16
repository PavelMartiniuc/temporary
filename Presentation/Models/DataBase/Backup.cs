/*

public partial class ArtistForeign
    {
        public int id { get; set; }
        [Required(ErrorMessage="Наименование зарубежного исполнителя обязательно")]
        [ArtistForeignUniqueName(ErrorMessage = "Зарубежный исполнитель с таким именем уже существует")]
        public string name { get; set; }
        public string biography { get; set; }
        public bool deleted { get; set; }
        [Required]
        public bool isPopular { get; set; }
    }

*/

/*
public partial class ArtistRusian
    {
        public int id { get; set; }
        [Required(ErrorMessage="Наименование русского исполнителя обязательно")]
        [ArtistRussianUniqueName(ErrorMessage = "Русский исполнитель с таким именем уже существует")]
        public string name { get; set; }
        public string biography { get; set; }
        public bool deleted { get; set; }
        [Required]
        public bool isPopular { get; set; }
    }
 */

/*
  public partial class Theme
    {
        public int id { get; set; }
        [Required(ErrorMessage="название темы обязатеьно")]
        [ThemeUniqueName(ErrorMessage = "Такая тема уже существует")]
        public string name { get; set; }
        public bool deleted { get; set; }
    }
*/

/*
   public partial class SongRusian
    {
        public long id { get; set; }
        public Nullable<int> artistId { get; set; }
        public Nullable<int> themeId { get; set; }
        [Required]
        public bool isNew { get; set; }
        [Required(ErrorMessage="Название русской песни обязательно")]
        [MaxLength(100,ErrorMessage="Максимальная длина названия - 100 символов")]
        public string name { get; set; }
        [Required]
        public string chords { get; set; }
        public bool deleted { get; set; }
    }
*/

/*
 public partial class SongForeign
    {
        public long id { get; set; }
        public Nullable<int> artistId { get; set; }
        public Nullable<int> themeId { get; set; }
        [Required]
        public bool isNew { get; set; }
        [Required(ErrorMessage="Название зарубежной песни обязательно")]
        [MaxLength(100,ErrorMessage="Максимальная длина названия - 100 символов")]
        public string name { get; set; }
        [Required]
        public string chords { get; set; }
        public bool deleted { get; set; }
    }
 */