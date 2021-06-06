namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("countries")]
    public partial class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        [Column("country_id")]
        [Key]
        public int CountryId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
