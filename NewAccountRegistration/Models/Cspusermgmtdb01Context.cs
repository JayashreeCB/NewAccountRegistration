using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewAccountRegistration.Models;

public partial class Cspusermgmtdb01Context : DbContext
{
    public Cspusermgmtdb01Context()
    {
    }

    public Cspusermgmtdb01Context(DbContextOptions<Cspusermgmtdb01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<Allocation> Allocations { get; set; }

    public virtual DbSet<AllocationMapping> AllocationMappings { get; set; }

    public virtual DbSet<ApiactivityLog> ApiactivityLogs { get; set; }

    public virtual DbSet<OranizationAddressMapping> OranizationAddressMappings { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblSkill> TblSkills { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserAddressMapping> UserAddressMappings { get; set; }

    public virtual DbSet<UserAllocationPermissionsMapping> UserAllocationPermissionsMappings { get; set; }

    public virtual DbSet<UserOrganizationMapping> UserOrganizationMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql-csp-devizdb-sql01.database.windows.net;Database=cspusermgmtdb01;Integrated Security=True;User Id=sqladmin;Password=CSPms@dbsrv01;Trusted_Connection= False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_OrganizationAdrdresses");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
            entity.Property(e => e.BuildingName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HouseNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsBillingAddressDifferent).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsMailingAddressDifferent).HasDefaultValueSql("((0))");
            entity.Property(e => e.LevelNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.Property(e => e.AddressTypeId).ValueGeneratedNever();
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Allocation>(entity =>
        {
            entity.HasKey(e => e.PropertyAllocationId);

            entity.HasIndex(e => e.AllocationId, "IX_Allocations").IsUnique();

            entity.Property(e => e.PropertyAllocationId).ValueGeneratedNever();
            entity.Property(e => e.AllocationId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AllocationType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndustryType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PropertyAdress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PropertyName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AllocationMapping>(entity =>
        {
            entity.ToTable("AllocationMapping");

            entity.Property(e => e.AllocationMappingId).ValueGeneratedNever();

            entity.HasOne(d => d.Organization).WithMany(p => p.AllocationMappings)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_AllocationMapping_Organizations");

            entity.HasOne(d => d.PropertyAllocation).WithMany(p => p.AllocationMappings)
                .HasForeignKey(d => d.PropertyAllocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllocationMapping_Allocations");

            entity.HasOne(d => d.User).WithMany(p => p.AllocationMappings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AllocationMapping_Users");
        });

        modelBuilder.Entity<ApiactivityLog>(entity =>
        {
            entity.HasKey(e => e.ApiactivityId);

            entity.ToTable("APIActivityLog");

            entity.Property(e => e.ApiactivityId)
                .ValueGeneratedNever()
                .HasColumnName("APIActivityId");
            entity.Property(e => e.Apiname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APIName");
            entity.Property(e => e.ResponseStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TriggerTime).HasColumnType("datetime");

            entity.HasOne(d => d.UserOrg).WithMany(p => p.ApiactivityLogs)
                .HasForeignKey(d => d.UserOrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIActivityLog_UserOrganizationMapping");
        });

        modelBuilder.Entity<OranizationAddressMapping>(entity =>
        {
            entity.HasKey(e => e.OrganizationAddressId);

            entity.ToTable("OranizationAddressMapping");

            entity.Property(e => e.OrganizationAddressId).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.OranizationAddressMappings)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OranizationAddressMapping_Adrdresses");

            entity.HasOne(d => d.AddressType).WithMany(p => p.OranizationAddressMappings)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OranizationAddressMapping_AddressTypes");

            entity.HasOne(d => d.Oranization).WithMany(p => p.OranizationAddressMappings)
                .HasForeignKey(d => d.OranizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OranizationAddressMapping_Organizations");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("PK_Organization");

            entity.HasIndex(e => e.Uen, "IX_Organization").IsUnique();

            entity.Property(e => e.OrganizationId).ValueGeneratedNever();
            entity.Property(e => e.LegalEntity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Uen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UEN");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.PermissionId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tblEmplo__7AD04FF16E149121");

            entity.ToTable("tblEmployees");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SkillId).HasColumnName("SkillID");
        });

        modelBuilder.Entity<TblSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__tblSkill__DFA091E7232CD783");

            entity.ToTable("tblSkills");

            entity.Property(e => e.SkillId).HasColumnName("SkillID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.SingPassId, "IX_Users").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.AllowNotificationByEmail).HasDefaultValueSql("((0))");
            entity.Property(e => e.AllowNotificationBySms)
                .HasDefaultValueSql("((0))")
                .HasColumnName("AllowNotificationBySMS");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salutation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SingPassId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.ToTable("UserActivity");

            entity.Property(e => e.UserActivityId).ValueGeneratedNever();
            entity.Property(e => e.ActivityPerformedTime).HasColumnType("datetime");
            entity.Property(e => e.ActivtiyDescripton)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.UserOrg).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserOrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserActivity_UserOrganizationMapping");
        });

        modelBuilder.Entity<UserAddressMapping>(entity =>
        {
            entity.HasKey(e => e.UserAddressId);

            entity.ToTable("UserAddressMapping");

            entity.Property(e => e.UserAddressId).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.UserAddressMappings)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAddressMapping_Adrdresses");

            entity.HasOne(d => d.AddressType).WithMany(p => p.UserAddressMappings)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAddressMapping_AddressTypes");

            entity.HasOne(d => d.User).WithMany(p => p.UserAddressMappings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAddressMapping_Users");
        });

        modelBuilder.Entity<UserAllocationPermissionsMapping>(entity =>
        {
            entity.HasKey(e => e.UserAllocationPermissionId);

            entity.ToTable("UserAllocationPermissionsMapping");

            entity.Property(e => e.UserAllocationPermissionId).ValueGeneratedNever();

            entity.HasOne(d => d.AllocationMapping).WithMany(p => p.UserAllocationPermissionsMappings)
                .HasForeignKey(d => d.AllocationMappingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAllocationPermissionsMapping_AllocationMapping");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserAllocationPermissionsMappings)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAllocationPermissionsMapping_Permissions");

            entity.HasOne(d => d.UserOrg).WithMany(p => p.UserAllocationPermissionsMappings)
                .HasForeignKey(d => d.UserOrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAllocationPermissionsMapping_UserOrganizationMapping");
        });

        modelBuilder.Entity<UserOrganizationMapping>(entity =>
        {
            entity.HasKey(e => e.UserOrgId);

            entity.ToTable("UserOrganizationMapping");

            entity.HasIndex(e => e.UserOrgId, "IX_UserOrganizationMapping");

            entity.Property(e => e.UserOrgId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsTaCaccepted).HasColumnName("IsTaCAccepted");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Organization).WithMany(p => p.UserOrganizationMappings)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_UserOrganizationMapping_Organizations");

            entity.HasOne(d => d.User).WithMany(p => p.UserOrganizationMappings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserOrganizationMapping_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
