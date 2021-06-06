namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("houses")]
    public partial class House
    {
        public House()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        [Column("house_id")]
        [Key]
        public int HouseId { get; set; }

        [Column("street_id")]
        public int StreetId { get; set; }

        [Column("number")]
        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }

        public virtual Street Street { get; set; }
    }
}
