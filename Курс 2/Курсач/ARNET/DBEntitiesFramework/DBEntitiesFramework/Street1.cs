namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("streets")]
    public partial class Street
    {
        public Street()
        {
            Houses = new HashSet<House>();
        }

        [Column("street_id")]
        [Key]
        public int StreetId { get; set; }

        [Column("city_id")]
        public int CityId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<House> Houses { get; set; }
    }
}
