using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Agency
{
    public class AgentApartmentsViewModel
    {
        public Arnet.Database.Account Agent { get; set; }
        public SelectApartment[] SelectApartments { get; set; }
    }

    public class SelectApartment
    {
        public Arnet.Database.Apartment Apartment { get; set; }

        public bool IsSelected { get; set; }
    }
}
