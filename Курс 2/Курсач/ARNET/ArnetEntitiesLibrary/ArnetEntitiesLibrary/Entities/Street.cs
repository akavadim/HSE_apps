using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Street
    {
        public Street()
        {
            Houses = new HashSet<House>();
        }

        public int StreetId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
