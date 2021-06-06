namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cities")]
    public partial class City
    {
        public City()
        {
            Streets = new HashSet<Street>();
        }

        [Column("city_id")]
        [Key]
        public int CityId { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}
