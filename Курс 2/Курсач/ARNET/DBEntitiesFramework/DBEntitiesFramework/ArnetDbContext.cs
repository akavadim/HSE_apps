namespace DBEntitiesFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArnetDbContext : DbContext
    {
        public ArnetDbContext()
            : base("name=ArnetDbModel")
        {
        }

        public virtual DbSet<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }
        public virtual DbSet<AccommodationType> AccommodationTypes { get; set; }
        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<BanReason> BanReasons { get; set; }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PublishmentSpecificationLink> PublishmentSpecificationLinks { get; set; }
        public virtual DbSet<PublishmentType> PublishmentTypes { get; set; }
        public virtual DbSet<Publishment> Publishments { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccommodationType>()
                .HasMany(e => e.Accommodations)
                .WithRequired(e => e.AccommodationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Accommodation>()
                .HasMany(e => e.AccommodationSpecificationLinks)
                .WithRequired(e => e.Accommodation)
                .HasForeignKey(e => e.AccomodationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Accommodation>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.Accommodation)
                .HasForeignKey(e => e.AccommodationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.Inviter)
                .HasForeignKey(e => e.InviterId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Emails)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Passwords)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Bans)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Images)
                .WithMany(e => e.Apartments)
                .Map(m =>
                {
                    m.ToTable("apartment_image_links");
                    m.MapLeftKey("apartment_id");
                    m.MapRightKey("image_id");
                });

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.ApartmentSpecificationLinks)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Publishments)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BanReason>()
                .HasMany(e => e.Bans)
                .WithRequired(e => e.BanReason)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Regions)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<House>()
                .HasMany(e => e.Accommodations)
                .WithRequired(e => e.House)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublishmentType>()
                .HasMany(e => e.Publishments)
                .WithRequired(e => e.PublishmentType)
                .HasForeignKey(e => e.PublishmetTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publishment>()
                .HasMany(e => e.PublishmentSpecificationLinks)
                .WithRequired(e => e.Publishment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specification>()
                .HasMany(e => e.AccommodationSpecificationLinks)
                .WithRequired(e => e.Specification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specification>()
                .HasMany(e => e.ApartmentSpecificationLinks)
                .WithRequired(e => e.Specification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specification>()
                .HasMany(e => e.PublishmentSpecificationLinks)
                .WithRequired(e => e.Specification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);
        }
    }
}
