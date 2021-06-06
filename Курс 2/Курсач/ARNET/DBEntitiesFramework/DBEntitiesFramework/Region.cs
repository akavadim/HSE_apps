namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("regions")]
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        [Column("region_id")]
        [Key]
        public int RegionId { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual Country Country { get; set; }
    }
}
