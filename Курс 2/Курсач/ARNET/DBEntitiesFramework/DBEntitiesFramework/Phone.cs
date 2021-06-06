namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phones")]
    public partial class Phone
    {
        [Column("phone_id")]
        [Key]
        public int PhoneId { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("number")]
        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
    }
}
