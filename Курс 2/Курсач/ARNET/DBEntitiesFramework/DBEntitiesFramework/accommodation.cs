namespace DBEntitiesFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Accommodations")]
    public partial class Accommodation
    {
        public Accommodation()
        {
            AccommodationSpecificationLinks = new HashSet<AccommodationSpecificationLink>();
            Apartments = new HashSet<Apartment>();
        }

        [Column("accommodation_id")]
        [Key]
        public int AccommodationId { get; set; }

        [Column("accommodation_type_id")]
        public int AccommodationTypeId { get; set; }

        [Column("house_id")]
        public int HouseId { get; set; }

        [Column("date_from")]
        public DateTime DateFrom { get; set; }

        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public virtual AccommodationType AccommodationType { get; set; }

        public virtual House House { get; set; }


        public virtual ICollection<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
