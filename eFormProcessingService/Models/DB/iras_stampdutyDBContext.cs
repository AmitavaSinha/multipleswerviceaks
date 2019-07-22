using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eFormProcessingService.Models.DB
{
    public partial class iras_stampdutyDBContext : DbContext
    {
        public iras_stampdutyDBContext()
        {
        }

        public iras_stampdutyDBContext(DbContextOptions<iras_stampdutyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<DocumentTypeMaster> DocumentTypeMaster { get; set; }
        public virtual DbSet<IdentityTypeMaster> IdentityTypeMaster { get; set; }
        public virtual DbSet<PartyPropertyDetailsTransaction> PartyPropertyDetailsTransaction { get; set; }
        public virtual DbSet<PostalCodeMaster> PostalCodeMaster { get; set; }
        public virtual DbSet<ProfileMaster> ProfileMaster { get; set; }
        public virtual DbSet<PropertyDetailsTransaction> PropertyDetailsTransaction { get; set; }
        public virtual DbSet<PropertyLevelUnitTransaction> PropertyLevelUnitTransaction { get; set; }
        public virtual DbSet<PropertyTypeMaster> PropertyTypeMaster { get; set; }
        public virtual DbSet<StampDutyCalculation> StampDutyCalculation { get; set; }
        public virtual DbSet<StampSaleAndPurchaseOfProperty> StampSaleAndPurchaseOfProperty { get; set; }
        public virtual DbSet<StampsPaymentDetails> StampsPaymentDetails { get; set; }
        public virtual DbSet<VendorTransaction> VendorTransaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=irasdb.database.windows.net;Database=iras_stampdutyDB;Uid=irasuser;Password=india@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentTypeMaster>(entity =>
            {
                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentityTypeMaster>(entity =>
            {
                entity.Property(e => e.IdentityTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartyPropertyDetailsTransaction>(entity =>
            {
                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelUnit1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelUnit2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressCountry)
                    .HasColumnName("MailingAddress_Country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseLiableAdditional)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.PartyPropertyDetailsTransaction)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_PartyPropertyDetailsTransaction_CountryMaster");

                entity.HasOne(d => d.IdentityType)
                    .WithMany(p => p.PartyPropertyDetailsTransaction)
                    .HasForeignKey(d => d.IdentityTypeId)
                    .HasConstraintName("FK_PartyPropertyDetailsTransaction_IdentityTypeMaster");

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.PartyPropertyDetailsTransaction)
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("FK_PartyPropertyDetailsTransaction_PostalCodeMaster");

                entity.HasOne(d => d.ProfileType)
                    .WithMany(p => p.PartyPropertyDetailsTransaction)
                    .HasForeignKey(d => d.ProfileTypeId)
                    .HasConstraintName("FK_PartyPropertyDetailsTransaction_ProfileMaster");

                entity.HasOne(d => d.SalesDuty)
                    .WithMany(p => p.PartyPropertyDetailsTransaction)
                    .HasForeignKey(d => d.SalesDutyId)
                    .HasConstraintName("FK_PartyPropertyDetailsTransaction_StampSaleAndPurchaseOfProperty");
            });

            modelBuilder.Entity<PostalCodeMaster>(entity =>
            {
                entity.Property(e => e.Blk)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfileMaster>(entity =>
            {
                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyDetailsTransaction>(entity =>
            {
                entity.Property(e => e.HouseNumbe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PostalCode)
                    .WithMany(p => p.PropertyDetailsTransaction)
                    .HasForeignKey(d => d.PostalCodeId)
                    .HasConstraintName("FK_PropertyDetailsTransaction_PostalCodeMaster");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.PropertyDetailsTransaction)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .HasConstraintName("FK_PropertyDetailsTransaction_PropertyTypeMaster");

                entity.HasOne(d => d.SalesDuty)
                    .WithMany(p => p.PropertyDetailsTransaction)
                    .HasForeignKey(d => d.SalesDutyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyDetailsTransaction_StampSaleAndPurchaseOfProperty");
            });

            modelBuilder.Entity<PropertyLevelUnitTransaction>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LevelUnit1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LevelUnit2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertyDetails)
                    .WithMany(p => p.PropertyLevelUnitTransaction)
                    .HasForeignKey(d => d.PropertyDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyLevelUnitTransaction_PropertyDetailsTransaction");
            });

            modelBuilder.Entity<PropertyTypeMaster>(entity =>
            {
                entity.Property(e => e.PropertyTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StampDutyCalculation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaxSlab).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MinSlab).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StampSaleAndPurchaseOfProperty>(entity =>
            {
                entity.Property(e => e.AdditionalComments)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfTheDocument).HasColumnType("datetime");

                entity.Property(e => e.DocumentRefNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentRefYear)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentRefNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.YourReferenceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EamilId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StampDutyCalculation)
                    .HasColumnName("StampDutyCalculation")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FloorArearSqm)
                    .HasColumnName("FloorArear_sqm")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OverseasDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");

                entity.Property(e => e.PurchasePriseOrConsideration).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShareOfPropertyTransferred)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StampDutyCalculation).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StampSaleAndPurchaseOfPropertyId)
                    .IsRequired()
                    .HasColumnName("StampSaleAndPurchaseOfPropertyId ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YourReferenceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.StampSaleAndPurchaseOfProperty)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_StampSaleAndPurchaseOfProperty_DocumentTypeMaster");
            });

            modelBuilder.Entity<StampsPaymentDetails>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsPaid)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");

                entity.Property(e => e.StampDuty).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<VendorTransaction>(entity =>
            {
                entity.Property(e => e.IdentityNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityType)
                    .WithMany(p => p.VendorTransaction)
                    .HasForeignKey(d => d.IdentityTypeId)
                    .HasConstraintName("FK_VendorTransaction_IdentityTypeMaster");

                entity.HasOne(d => d.SalesDuty)
                    .WithMany(p => p.VendorTransaction)
                    .HasForeignKey(d => d.SalesDutyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VendorTransaction_StampSaleAndPurchaseOfProperty");
            });
        }
    }
}
