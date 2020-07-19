using System.ComponentModel.DataAnnotations;

namespace MovCat.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Некорректный Логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Некорректный Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль должен состоять из восьми или более символов латинского алфавита, содержать заглавные и строчные буквы, знаки припинания, цифры.")]
        public string Password { get; set; }

    }
}
