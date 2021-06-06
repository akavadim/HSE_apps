using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Arnet.Database;
using Arnet.Library;


namespace Arnet.Web.Areas.Account.Models.Registration
{
    public class PhoneModel
    {
        [Required(ErrorMessage = "Введите номер телефоона")]
        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]   //TODO: другие сообщения об ошибках
        [RegularExpression(@"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$", ErrorMessage ="Некорректный номер телефона")]
        [MaxLength(12)]
        public string Phone { get; set; }

        public Phone ToPhone()
        {
            Phone phone = new Phone()
            {
                Number = PhoneConverter.TryCreatePhone(this.Phone).Number,
                DateFrom = DateTime.UtcNow
            };

            return phone;
        }
    }

}
