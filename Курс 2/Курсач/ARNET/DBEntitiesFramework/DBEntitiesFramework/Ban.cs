namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bans")]
    public partial class Ban
    {
        [Column("ban_id")]
        [Key]
        public int BanId { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("ban_reason_id")]
        public int BanReasonId { get; set; }

        [Column("comment")]
        [StringLength(200)]
        public string Comment { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }

        public virtual BanReason BanReason { get; set; }
    }
}
