using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class ApartmentSpecificationLink
    {
        public int ApartmentSpecificationId { get; set; }
        public int SpecificationId { get; set; }
        public int ApartmentId { get; set; }
        public string Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
