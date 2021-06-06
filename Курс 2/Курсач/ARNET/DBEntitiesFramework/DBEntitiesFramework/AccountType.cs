namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account_types")]
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        [Column("account_type_id")]
        [Key]
        public int AccountTypeId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
