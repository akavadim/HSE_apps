namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("specifications")]
    public partial class Specification
    {
        public Specification()
        {
            AccommodationSpecificationLinks = new HashSet<AccommodationSpecificationLink>();
            ApartmentSpecificationLinks = new HashSet<ApartmentSpecificationLink>();
            PublishmentSpecificationLinks = new HashSet<PublishmentSpecificationLink>();
        }

        [Column("specification_id")]
        [Key]
        public int SpecificationId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }

        public virtual ICollection<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }

        public virtual ICollection<PublishmentSpecificationLink> PublishmentSpecificationLinks { get; set; }
    }
}
