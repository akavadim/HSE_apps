using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Publishment
    {
        public Publishment()
        {
            PublishmentSpecificationLinks = new HashSet<PublishmentSpecificationLink>();
        }

        public int PublishmentId { get; set; }
        public int ApartmentId { get; set; }
        public int PublishmetTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual PublishmentType PublishmetType { get; set; }
        public virtual ICollection<PublishmentSpecificationLink> PublishmentSpecificationLinks { get; set; }
    }
}
