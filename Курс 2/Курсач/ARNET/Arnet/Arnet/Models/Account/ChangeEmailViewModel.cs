using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Account
{
    public class ChangeEmailViewModel
    {
        public Email Email { get; set; }
        public string NewEmail { get; set; }
    }
}
