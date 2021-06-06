using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Specification
    {
        public Specification()
        {
            AccommodationSpecificationLinks = new HashSet<AccommodationSpecificationLink>();
            ApartmentSpecificationLinks = new HashSet<ApartmentSpecificationLink>();
            PublishmentSpecificationLinks = new HashSet<PublishmentSpecificationLink>();
        }

        public int SpecificationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }
        public virtual ICollection<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }
        public virtual ICollection<PublishmentSpecificationLink> PublishmentSpecificationLinks { get; set; }
    }
}
