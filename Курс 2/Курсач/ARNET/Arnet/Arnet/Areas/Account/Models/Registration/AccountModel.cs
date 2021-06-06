using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Arnet.Database;

namespace Arnet.Web.Areas.Account.Models.Registration
{
    public class AccountModel
    {
        [Display(Name = "Имя*")]
        [Required(ErrorMessage ="Введите имя")]
        public string FirstName { get; set; }

        [Display(Name ="Фамилия*")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string SecondName { get; set; }
        
        [Display(Name = "Электронная почта")]
        [EmailAddress(ErrorMessage ="Некорректный адрес электронной почты")]
        public string Email { get; set; }

        [Display(Name = "Пароль*")]
        [Required(ErrorMessage ="Введите пароль")]
        [MinLength(6, ErrorMessage ="Пароль не может быть короче 6 символов")]
        public string Password { get; set; }

        public Arnet.Database.Account ToAccount()
        {

            Arnet.Database.Account account = new Database.Account()
            {
                DateFrom = DateTime.UtcNow,
                FirstName = this.FirstName,
                SecondName = this.SecondName,
            };

            if (!string.IsNullOrWhiteSpace(Email))
            {
                Email email = new Email() { DateFrom = DateTime.UtcNow, Value = Email };
                account.Emails.Add(email);
            }

            Password password = new Password() { Value = Password, DateFrom = DateTime.UtcNow };
            account.Passwords.Add(password);

            return account;
        }
    }
}
