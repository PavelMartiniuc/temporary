using Gitarist.Areas.Admin.ValidationAttributes;
using Gitarist.Models.DataBase;
using System.ComponentModel.DataAnnotations;


namespace Gitarist.Areas.Admin.Models
{
    public class ThemeViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "название темы обязатеьно")]
        [ThemeUniqueName(ErrorMessage = "Такая тема уже существует")]
        public string name { get; set; }
        public bool deleted { get; set; }

        [ThemeClearUrlUnique(ErrorMessage="Такая Чпу для темы уже существует")]
        public string clearUrlName { get; set; }

        public ThemeViewModel()
        {
            
        }

        public ThemeViewModel(Theme dbModel)
        {
            LoadFromDbModel(dbModel);
        }

        public Theme DbModel
        {
            get
            {
                return new Theme
                {
                    id = this.id,
                    name = this.name,
                    deleted = this.deleted,
                    clearUrlName = this.clearUrlName
                };
            }
        }

        public void LoadFromDbModel(Theme dbModel)
        {
            this.id = dbModel.id;
            this.name = dbModel.name;
            this.deleted = dbModel.deleted;
            this.clearUrlName = dbModel.clearUrlName;
        }
    }
}