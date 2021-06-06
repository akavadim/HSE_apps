using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;
using System.Data;

namespace Arnet.Web.Models.Admin
{
    public class ReportsViewModel
    {

        public DataTable NewUsers { get; set; }

        public DataTable NewPublishmetns { get; set; }
    }
}
