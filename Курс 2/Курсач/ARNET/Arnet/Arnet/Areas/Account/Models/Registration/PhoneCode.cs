using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Web.Areas.Account.Models.Registration
{
    public class PhoneCode
    {
        [Display(Name ="Код из смс", Description ="Тест")]  //TODO: Тест
        [Required(ErrorMessage ="Введите код")]
        [StringLength(6, MinimumLength =6, ErrorMessage ="Неправильный код")]
        public string Code { get; set; }
    }
}
