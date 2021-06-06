using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class PublishmentSpecificationLink
    {
        public int PublishmentSpecificationId { get; set; }
        public int PublishmentId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Publishment Publishment { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
