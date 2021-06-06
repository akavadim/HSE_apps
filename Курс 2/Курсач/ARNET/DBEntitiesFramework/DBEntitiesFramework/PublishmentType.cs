namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("publishment_types")]
    public partial class PublishmentType
    {
        public PublishmentType()
        {
            Publishments = new HashSet<Publishment>();
        }

        [Column("publishment_type_id")]
        [Key]
        public int PublishmentTypeId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Publishment> Publishments { get; set; }
    }
}
