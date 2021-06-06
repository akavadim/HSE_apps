using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Admin
{
    public class UserViewModel
    {
        public Arnet.Database.Account Account { get; set; }

        public Phone Phone { get; set; }

        public Ban Ban { get; set; }
    }
}
