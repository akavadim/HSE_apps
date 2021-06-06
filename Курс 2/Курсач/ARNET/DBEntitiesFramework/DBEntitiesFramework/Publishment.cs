namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("publishments")]
    public partial class Publishment
    {
        public Publishment()
        {
            PublishmentSpecificationLinks = new HashSet<PublishmentSpecificationLink>();
        }

        [Column("publishment_id")]
        [Key]
        public int PublishmentId { get; set; }

        [Column("apartment_id")]
        public int ApartmentId { get; set; }

        [Column("publishment_type_id")]
        public int PublishmetTypeId { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual ICollection<PublishmentSpecificationLink> PublishmentSpecificationLinks { get; set; }

        public virtual PublishmentType PublishmentType { get; set; }
    }
}
