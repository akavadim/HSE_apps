namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("accommodation_specification_links")]
    public partial class AccommodationSpecificationLink
    {
        [Column("accommodation_specification_id")]
        [Key]
        public int AccomodationSpecificationId { get; set; }

        [Column("accommodation_id")]
        public int AccomodationId { get; set; }

        [Column("specification_id")]
        public int SpecificationId { get; set; }

        [Column("value")]
        [Required]
        [StringLength(30)]
        public string Value { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        public virtual Specification Specification { get; set; }
    }
}
