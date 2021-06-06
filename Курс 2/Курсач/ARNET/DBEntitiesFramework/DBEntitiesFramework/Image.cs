namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("images")]
    public partial class Image
    {
        public Image()
        {
            Accounts = new HashSet<Account>();
            Apartments = new HashSet<Apartment>();
        }

        [Column("image_id")]
        [Key]
        public int ImageId { get; set; }

        [Column("value",TypeName = "image")]
        [Required]
        public byte[] Value { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
