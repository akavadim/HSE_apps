using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите номер телефоона")]
        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]   //TODO: другие сообщения об ошибках
        [RegularExpression(@"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$", ErrorMessage = "Некорректный номер телефона")]
        [MaxLength(12)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль не может быть короче 6 символов")]
        public string Password { get; set; }
    }
}
