namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("accounts")]
    public partial class Account
    {
        public Account()
        {
            Accounts = new HashSet<Account>();
            Apartments = new HashSet<Apartment>();
            Emails = new HashSet<Email>();
            Passwords = new HashSet<Password>();
            Phones = new HashSet<Phone>();
            Bans = new HashSet<Ban>();
        }

        [Column("account_id")]
        [Key]
        public int AccountId { get; set; }

        [Column("account_type_id")]
        public int AccountTypeId { get; set; }

        [Column("image_id")]
        public int? ImageId { get; set; }

        [Column("inviter_id")]
        public int? InviterId { get; set; }

        [Column("first_name")]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Column("second_name")]
        [StringLength(25)]
        public string SecondName { get; set; }

        [Column("middle_name")]
        [StringLength(25)]
        public string MiddleName { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual Account Inviter { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Password> Passwords { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public virtual ICollection<Ban> Bans { get; set; }
    }
}
