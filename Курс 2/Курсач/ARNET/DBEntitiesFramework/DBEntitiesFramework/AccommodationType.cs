namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("accommodation_types")]
    public partial class AccommodationType
    {
        public AccommodationType()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        [Column("accommodation_type_id")]
        [Key]
        public int AccommodationTypeId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
