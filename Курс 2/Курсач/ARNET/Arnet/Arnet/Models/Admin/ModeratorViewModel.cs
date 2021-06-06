using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Admin
{
    public class ModeratorViewModel
    {
        public Arnet.Database.Account Account { get; set; }
        public Arnet.Database.Phone Phone { get; set; }
    }
}
