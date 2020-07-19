using System.ComponentModel.DataAnnotations;

namespace MovCat.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Некорректный Логин")]
        [UIHint("login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Некорректный Пароль")]
        [DataType(DataType.Password)]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
