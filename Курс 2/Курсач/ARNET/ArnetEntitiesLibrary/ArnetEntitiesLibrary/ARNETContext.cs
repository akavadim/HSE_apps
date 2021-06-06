using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class ARNETContext : DbContext
    {
        public ARNETContext()
        {
        }

        public ARNETContext(DbContextOptions<ARNETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccommodationSpecificationLink> AccommodationSpecificationLinks { get; set; }
        public virtual DbSet<AccommodationType> AccommodationTypes { get; set; }
        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<AccountTypes> AccountTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ApartmentImageLink> ApartmentImageLinks { get; set; }
        public virtual DbSet<ApartmentSpecificationLink> ApartmentSpecificationLinks { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
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
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<CompanyInvite> CompanyInvites { get; set; }
        public virtual DbSet<ModeratorInvite> ModeratorInvites { get; set; }
        public virtual DbSet<CompanyComplaint> CompanyComplaints { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<AccountComplaint> AccountComplaints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PC\\SQLEXPRESS;initial catalog=ARNET;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccommodationSpecificationLink>(entity =>
            {
                entity.HasKey(e => e.AccommodationSpecificationId)
                    .HasName("PK__accommod__FD91E793AB0FE25A");

                entity.ToTable("accommodation_specification_links");

                entity.HasIndex(e => new { e.AccommodationId, e.SpecificationId })
                    .HasName("idx_accommodation_specification_links_accommodation_id_specification_id");

                entity.Property(e => e.AccommodationSpecificationId).HasColumnName("accommodation_specification_id");

                entity.Property(e => e.AccommodationId).HasColumnName("accommodation_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecificationId).HasColumnName("specification_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.AccommodationSpecificationLinks)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accommoda__accom__0CFADF99");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.AccommodationSpecificationLinks)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accommoda__speci__2B2A60FE");
            });

            modelBuilder.Entity<AccommodationType>(entity =>
            {
                entity.HasKey(e => e.AccommodationTypeId)
                    .HasName("PK__accommod__9C2D86DD1F8E77BC");

                entity.ToTable("accommodation_types");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__accommod__72E12F1BDFD298B3")
                    .IsUnique();

                entity.Property(e => e.AccommodationTypeId).HasColumnName("accommodation_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.HasKey(e => e.AccommodationId)
                    .HasName("PK__accommod__004EC32581334A2D");

                entity.ToTable("accommodations");

                entity.HasIndex(e => new { e.HouseId, e.AccommodationTypeId })
                    .HasName("idx_accommodations_house_id_accommodation_type_id");

                entity.Property(e => e.AccommodationId).HasColumnName("accommodation_id");

                entity.Property(e => e.AccommodationTypeId).HasColumnName("accommodation_type_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.HouseId).HasColumnName("house_id");

                entity.HasOne(d => d.AccommodationType)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.AccommodationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.HouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accommoda__house__18178C8A");
            });

            modelBuilder.Entity<AccountTypes>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId)
                    .HasName("PK__account___18186C10CCD61221");

                entity.ToTable("account_types");

                entity.HasIndex(e => e.Type)
                    .HasName("UQ__account___72E12F1BD18DB8C8")
                    .IsUnique();

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasConversion(
                    v => v.ToString(),
                    v => (AccountTypesEnum)Enum.Parse(typeof(AccountTypesEnum), v));
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__accounts__46A222CD9F6BCE79");

                entity.ToTable("accounts");

                entity.HasIndex(e => e.DateTo)
                    .HasName("idx_accounts_date_to");

                entity.HasIndex(e => new { e.InviterId, e.DateTo })
                    .HasName("idx_accounts_inviter_date_to");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(25);

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.InviterId).HasColumnName("inviter_id");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(25);

                entity.Property(e => e.SecondName)
                    .HasColumnName("second_name")
                    .HasMaxLength(25);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__accoun__7F80E8EA");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.Accounts)
                    .HasForeignKey<Account>(d => d.ImageId)
                    .HasConstraintName("FK__accounts__image___797309D9");

                entity.HasOne(d => d.Inviter)
                    .WithMany(p => p.InverseInviters)
                    .HasForeignKey(d => d.InviterId)
                    .HasConstraintName("FK__accounts__invite__7A672E12");
            });

            modelBuilder.Entity<ApartmentImageLink>(entity =>
            {
                entity.HasKey(e => e.ApartmentImageId)
                    .HasName("PK__apartmen__69BCC34FBE604AF4");

                entity.ToTable("apartment_image_links");

                entity.HasIndex(e => e.ApartmentId)
                    .HasName("idx_apartment_image_links_apartment_id");

                entity.Property(e => e.ApartmentImageId).HasColumnName("apartment_image_id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentImageLinks)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__apart__4850AF91");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.ApartmentImageLinks)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__image__4944D3CA");
            });

            modelBuilder.Entity<ApartmentSpecificationLink>(entity =>
            {
                entity.HasKey(e => e.ApartmentSpecificationId)
                    .HasName("PK__apartmen__EE31642B9922F690");

                entity.ToTable("apartment_specification_links");

                entity.HasIndex(e => e.ApartmentId)
                    .HasName("idx_apartment_specification_links_apartment_id");

                entity.Property(e => e.ApartmentSpecificationId).HasColumnName("apartment_specification_id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecificationId).HasColumnName("specification_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentSpecificationLinks)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__apart__1590259A");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.ApartmentSpecificationLinks)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__speci__149C0161");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.ApartmentId)
                    .HasName("PK__apartmen__DC51C2EC2D2927B9");

                entity.ToTable("apartments");

                entity.HasIndex(e => e.AccommodationId)
                    .HasName("idx_apartments_accomodation_id");

                entity.HasIndex(e => e.AccountId)
                    .HasName("idx_apartments_account_id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.AccommodationId).HasColumnName("accommodation_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__accom__11BF94B6");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__apartment__accou__381A47C8");
            });

            modelBuilder.Entity<Ban>(entity =>
            {
                entity.HasKey(e => e.BanId)
                    .HasName("PK_blocklist_block_id");

                entity.ToTable("bans");

                entity.Property(e => e.BanId).HasColumnName("ban_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(200);

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Bans)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_blocklist_accounts_account_id");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__cities__031491A8D90322A4");

                entity.ToTable("cities");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_cities_city");

                entity.HasIndex(e => new { e.RegionId, e.Name })
                    .HasName("idx_cities_region_id_city");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cities__region_i__5DEAEAF5");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_companies_company_id");

                entity.ToTable("companies");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_companies_accounts_account_id");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__countrie__7E8CD0558EA4DB83");

                entity.ToTable("countries");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_countries_country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__emails__3FEF876616F3F3D1");

                entity.ToTable("emails");

                entity.HasIndex(e => new { e.Value, e.DateTo })
                    .HasName("idx_emails_email_date_to");

                entity.Property(e => e.EmailId).HasColumnName("email_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__emails__account___45544755");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(e => e.HouseId)
                    .HasName("PK__houses__E24626411763628D");

                entity.ToTable("houses");

                entity.HasIndex(e => new { e.StreetId, e.HouseId })
                    .HasName("idx_houses_street_id");

                entity.Property(e => e.HouseId).HasColumnName("house_id");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(10);

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__houses__street_i__70FDBF69");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__images__DC9AC955EA67D3CE");

                entity.ToTable("images");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PasswordId)
                    .HasName("PK__password__82B1190E3B4E8FDF");

                entity.ToTable("passwords");

                entity.HasIndex(e => new { e.AccountId, e.DateTo })
                    .HasName("idx_passwords_account_id_date_to");

                entity.Property(e => e.PasswordId).HasColumnName("password_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passwords__accou__58671BC9");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.PhoneId)
                    .HasName("PK__phones__E6BD6DD72F8C3CFF");

                entity.ToTable("phones");

                entity.HasIndex(e => new { e.Number, e.DateTo })
                    .HasName("idx_phones_phone_date_to");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phones__account___186C9245");
            });

            modelBuilder.Entity<PublishmentSpecificationLink>(entity =>
            {
                entity.HasKey(e => e.PublishmentSpecificationId)
                    .HasName("PK__publishm__37FFA7A2BA058ABD");

                entity.ToTable("publishment_specification_links");

                entity.HasIndex(e => e.PublishmentId)
                    .HasName("idx_publishment_specification_links_publishment_id");

                entity.Property(e => e.PublishmentSpecificationId).HasColumnName("publishment_specification_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.PublishmentId).HasColumnName("publishment_id");

                entity.Property(e => e.SpecificationId).HasColumnName("specification_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Publishment)
                    .WithMany(p => p.PublishmentSpecificationLinks)
                    .HasForeignKey(d => d.PublishmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__publishme__publi__1CA7377D");

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.PublishmentSpecificationLinks)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__publishme__speci__1D9B5BB6");
            });

            modelBuilder.Entity<PublishmentType>(entity =>
            {
                entity.HasKey(e => e.PublishmentTypeId)
                    .HasName("PK__publishm__639F2CF8A66B5D3D");

                entity.ToTable("publishment_types");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__publishm__72E12F1BDA801344")
                    .IsUnique();

                entity.Property(e => e.PublishmentTypeId).HasColumnName("publishment_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Publishment>(entity =>
            {
                entity.HasKey(e => e.PublishmentId)
                    .HasName("PK__publishm__61B7F65DAAA6D34C");

                entity.ToTable("publishments");

                entity.HasIndex(e => e.ApartmentId)
                    .HasName("idx_publishments_apartment_id");

                entity.Property(e => e.PublishmentId).HasColumnName("publishment_id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.PublishmetTypeId).HasColumnName("publishmet_type_id");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Publishments)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__publishme__apart__6E765879");

                entity.HasOne(d => d.PublishmetType)
                    .WithMany(p => p.Publishments)
                    .HasForeignKey(d => d.PublishmetTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_publishments_publishment_types_publishment_type_id");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("PK__regions__01146BAE49491A92");

                entity.ToTable("regions");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_regions_regions");

                entity.HasIndex(e => new { e.CountryId, e.Name })
                    .HasName("idx_regions_country_id_region");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__regions__country__4AD81681");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecificationId)
                    .HasName("PK__specific__6DC4AC394EC4B360");

                entity.ToTable("specifications");

                entity.Property(e => e.SpecificationId).HasColumnName("specification_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.StreetId)
                    .HasName("PK__streets__665BB66BE8EDD772");

                entity.ToTable("streets");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_streets_street");

                entity.HasIndex(e => new { e.CityId, e.Name })
                    .HasName("idx_streets_city_id_street");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__streets__city_id__42CCE065");
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("agents");

                entity.HasKey(e => e.AgentId)
                .HasName("PK_Agents_agent_id");

                entity.Property(e => e.AgentId).HasColumnName("agent_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agents_companies_company_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_agents_accounts_account_id");
            });

            modelBuilder.Entity<ModeratorInvite>(entity =>
            {
                entity.HasKey(e => e.InviteId)
                    .HasName("PK_moderator_invites_id");

                entity.ToTable("moderator_invites");

                entity.HasIndex(e => e.Md5)
                    .HasName("UQ__moderato__DF502978755F6882")
                    .IsUnique();

                entity.Property(e => e.InviteId).HasColumnName("invite_id");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e=>e.Md5)
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CompanyInvite>(entity =>
            {
                entity.HasKey(e => e.InviteId)
                    .HasName("PK_company_invites_id");

                entity.ToTable("company_invites");

                entity.HasIndex(e => e.Md5)
                    .HasName("UQ__company___DF50297890D303F1")
                    .IsUnique();

                entity.Property(e => e.InviteId).HasColumnName("invite_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.Md5)
                    .HasColumnName("md5")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.CompanyInvites)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_company_invites_companies_company_id");
            });

            modelBuilder.Entity<CompanyComplaint>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_company_complaints_id");

                entity.ToTable("company_complaints");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ComplaintId).HasColumnName("complaint_id");

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.CompanyComplaints)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_company_complaints_companies_company_id");

                entity.HasOne(e => e.Complaint)
                    .WithOne(c => c.CompanyComplaint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_company_complaints_Complaints_id");
            });

            modelBuilder.Entity<AccountComplaint>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_account_complaints_id");

                entity.ToTable("account_complaints");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.ComplaintId).HasColumnName("complaint_id");

                entity.HasOne(e => e.Account)
                    .WithMany(c => c.AccountComplaints)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_complaints_accounts_account_id");

                entity.HasOne(e => e.Complaint)
                    .WithOne(c => c.AccountComplaint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_complaints_Complaints_id");
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Complaint_id");

                entity.ToTable("сomplaints");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Reason).HasColumnName("reason")
                .HasMaxLength(100).IsFixedLength();

                entity.Property(e => e.Response).HasColumnName("response")
                .HasMaxLength(100).IsFixedLength();

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");


                entity.HasOne(e => e.Sender)
                    .WithMany(c => c.Complaints)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_сomplaints_accounts_account_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}