using System;
using System.ComponentModel.DataAnnotations;

namespace Tehas.Frontend.Models
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "* Поле {0} должно быть установлено.")]
        [EmailAddress(ErrorMessage = "Неправильный email")]
        public String Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "* Поле {0} должно быть установлено.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public Boolean IsSave { get; set; }
    }
}