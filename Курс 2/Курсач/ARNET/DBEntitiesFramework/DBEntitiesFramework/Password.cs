namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("passwords")]
    public partial class Password
    {
        [Column("password_id")]
        [Key]
        public int PasswordId { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("value")]
        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
    }
}
