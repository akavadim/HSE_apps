using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class AccommodationSpecificationLink
    {
        public int AccommodationSpecificationId { get; set; }
        public int AccommodationId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Accommodation Accommodation { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
