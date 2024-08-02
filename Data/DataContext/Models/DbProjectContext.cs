using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext.Models;

public partial class DbProjectContext : DbContext
{
    public DbProjectContext()
    {
    }

    public DbProjectContext(DbContextOptions<DbProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdMenu> AdMenus { get; set; }

    public virtual DbSet<AdMenuPermission> AdMenuPermissions { get; set; }

    public virtual DbSet<AdOrganization> AdOrganizations { get; set; }

    public virtual DbSet<AdUser> AdUsers { get; set; }

    public virtual DbSet<AdUserLogin> AdUserLogins { get; set; }

    public virtual DbSet<InvItem> InvItems { get; set; }

    public virtual DbSet<InvItemCategory> InvItemCategories { get; set; }

    public virtual DbSet<InvStock> InvStocks { get; set; }

    public virtual DbSet<InvStockItem> InvStockItems { get; set; }

    public virtual DbSet<InvSupplier> InvSuppliers { get; set; }

    public virtual DbSet<SlsInvoice> SlsInvoices { get; set; }

    public virtual DbSet<SlsItemPrice> SlsItemPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DB_PROJECT;User Id=sa; Password=@Msi2023#;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdMenu>(entity =>
        {
            entity.ToTable("AD_Menu");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Url).HasMaxLength(200);
        });

        modelBuilder.Entity<AdMenuPermission>(entity =>
        {
            entity.ToTable("AD_MenuPermission");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<AdOrganization>(entity =>
        {
            entity.ToTable("AD_Organization");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdUser>(entity =>
        {
            entity.ToTable("AD_Users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BirthTime).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FullName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AdUserLogin>(entity =>
        {
            entity.ToTable("AD_UserLogin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.InverseUser)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AD_UserLogin_AD_UserLogin");
        });

        modelBuilder.Entity<InvItem>(entity =>
        {
            entity.ToTable("INV_Item");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ItemName).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.InvItems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_INV_Item_INV_ItemCategory");
        });

        modelBuilder.Entity<InvItemCategory>(entity =>
        {
            entity.ToTable("INV_ItemCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoryName).HasMaxLength(200);
        });

        modelBuilder.Entity<InvStock>(entity =>
        {
            entity.ToTable("INV_Stock");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.OrgId).HasColumnName("OrgID");

            entity.HasOne(d => d.Item).WithMany(p => p.InvStocks)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_INV_Stock_INV_Item");

            entity.HasOne(d => d.Org).WithMany(p => p.InvStocks)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK_INV_Stock_AD_Organization");
        });

        modelBuilder.Entity<InvStockItem>(entity =>
        {
            entity.ToTable("INV_StockItem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.LotNo).HasMaxLength(50);
            entity.Property(e => e.Qty).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.StockId).HasColumnName("StockID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
        });

        modelBuilder.Entity<InvSupplier>(entity =>
        {
            entity.ToTable("INV_Supplier");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.SupplierName).HasMaxLength(500);
        });

        modelBuilder.Entity<SlsInvoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SLS_Invoice");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<SlsItemPrice>(entity =>
        {
            entity.ToTable("SLS_ItemPrice");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 10)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
