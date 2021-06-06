using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Web.Areas.Account.Models.Registration
{
    public class NewAccountViewModel
    {
        [Required]
        public AccountModel AccountModel { get; set; }
        public CompanyModel CompanyModel { get; set; }
        public string InviteMd5 { get; set; }
    }
}
