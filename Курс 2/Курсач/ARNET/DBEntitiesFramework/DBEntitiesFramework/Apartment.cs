namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("apartments")]
    public partial class Apartment
    {
        public Apartment()
        {
            Images = new HashSet<Image>();
            ApartmentSpecificationLinks = new HashSet<ApartmentSpecificationLink>();
            Publishments = new HashSet<Publishment>();
        }

        [Column("apartment_id")]
        [Key]
        public int ApartmentId { get; set; }

        [Column("accommodation_id")]
        public int AccommodationId { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("description", TypeName = "ntext")]
        public string Description { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }

        public virtual ICollection<Publishment> Publishments { get; set; }
    }
}
