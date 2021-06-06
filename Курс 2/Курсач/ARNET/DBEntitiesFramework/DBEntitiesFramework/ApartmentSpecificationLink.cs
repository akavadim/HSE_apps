namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("apartment_specification_links")]
    public partial class ApartmentSpecificationLink
    {
        [Column("apartment_specification_id")]
        [Key]
        public int ApartmentSpecificationId { get; set; }

        [Column("specification_id")]
        public int SpecificationId { get; set; }

        [Column("apartment_id")]
        public int ApartmentId { get; set; }

        [Column("value")]
        [Required]
        [StringLength(30)]
        public string Value { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual Specification Specification { get; set; }
    }
}
