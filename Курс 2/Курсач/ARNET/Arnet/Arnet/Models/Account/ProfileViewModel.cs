using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Account
{
    public class ProfileViewModel
    {
        public Arnet.Database.Account Account { get; set; }

        public Phone Phone { get; set; }

        public Email Email { get; set; }

        public Company Agency { get; set; }

        public Ban Ban { get; set; }
    }
}
