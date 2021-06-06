using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Apartment
    {
        public Apartment()
        {
            ApartmentImageLinks = new HashSet<ApartmentImageLink>();
            ApartmentSpecificationLinks = new HashSet<ApartmentSpecificationLink>();
            Publishments = new HashSet<Publishment>();
        }

        public int ApartmentId { get; set; }
        public int AccommodationId { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Accommodation Accommodation { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<ApartmentImageLink> ApartmentImageLinks { get; set; }
        public virtual ICollection<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }
        public virtual ICollection<Publishment> Publishments { get; set; }
    }
}
