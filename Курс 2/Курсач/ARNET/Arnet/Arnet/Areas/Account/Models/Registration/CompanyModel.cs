using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Arnet.Database;

namespace Arnet.Web.Areas.Account.Models.Registration
{
    public class CompanyModel
    {
        [Display(Name="Название компании*")]
        [Required(ErrorMessage ="Введите название компании")]
        [MinLength(3, ErrorMessage = "Название компаниии не может быть короче 3-х символов")]
        public string Name { get; set; }

        public Company ToCompany()
        {

            Company company = new Company()
            {
                DateFrom = DateTime.UtcNow,
                Name = this.Name,
            };

            return company;
        }
    }
}
