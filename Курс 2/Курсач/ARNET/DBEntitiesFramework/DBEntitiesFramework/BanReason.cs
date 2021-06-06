namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ban_reasons")]
    public partial class BanReason
    {
        public BanReason()
        {
            Bans = new HashSet<Ban>();
        }

        [Column("block_reason_id")]
        [Key]
        public int BlockReasonId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Ban> Bans { get; set; }
    }
}
