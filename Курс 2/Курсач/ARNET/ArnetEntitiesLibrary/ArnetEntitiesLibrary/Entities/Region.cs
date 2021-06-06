using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
