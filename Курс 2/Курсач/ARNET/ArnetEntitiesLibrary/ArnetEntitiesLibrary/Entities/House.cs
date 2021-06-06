using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class House
    {
        public House()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int HouseId { get; set; }
        public int StreetId { get; set; }
        public string Number { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
