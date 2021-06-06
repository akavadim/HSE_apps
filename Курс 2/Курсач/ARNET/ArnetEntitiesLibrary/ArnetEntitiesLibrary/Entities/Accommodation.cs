using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Accommodation
    {
        public Accommodation()
        {
            AccommodationSpecificationLinks = new HashSet<AccommodationSpecificationLink>();
            Apartments = new HashSet<Apartment>();
        }

        public int AccommodationId { get; set; }
        public int AccommodationTypeId { get; set; }
        public int HouseId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual AccommodationType AccommodationType { get; set; }
        public virtual House House { get; set; }
        public virtual ICollection<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
