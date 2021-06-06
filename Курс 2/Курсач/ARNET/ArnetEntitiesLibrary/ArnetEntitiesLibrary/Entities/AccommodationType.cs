using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class AccommodationType
    {
        public AccommodationType()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int AccommodationTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
