using System.ComponentModel.DataAnnotations;

namespace Gitarist.Areas.Admin.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage="Введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        public bool RememeberMe { get; set; }

        public string ErrorMessage { get; set; }
    }
}