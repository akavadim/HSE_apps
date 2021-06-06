using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Models.Agency
{
    public class AgentsViewModel
    {
        public Arnet.Database.Account Agent { get; set; }
        public IEnumerable<Arnet.Database.Apartment> OpenedApartments { get; set; }
        public IEnumerable<Arnet.Database.Apartment> ClosedApartments { get; set; }
    }
}
