using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
