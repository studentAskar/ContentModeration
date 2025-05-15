using System;
using System.Collections.Generic;
using Domain.Entity;
using DomainDomain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class QueueDbContext : DbContext
{
    public QueueDbContext()
    {
    }

    public QueueDbContext(DbContextOptions<QueueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Domain.Entity.Action> Actions { get; set; }

    public virtual DbSet<ExceedingsTime> ExceedingsTimes { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<QueueItem> QueueItems { get; set; }

    public virtual DbSet<QueueType> QueueTypes { get; set; }

    public virtual DbSet<ReasonsForCancellation> ReasonsForCancellations { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<RecordStatus> RecordStatuses { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleAccess> RoleAccesses { get; set; }

    public virtual DbSet<RoleResourceAction> RoleResourceActions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPhoto> UserPhotos { get; set; }

    public virtual DbSet<UserService> UserServices { get; set; }

    public virtual DbSet<UserWindow> UserWindows { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    public virtual DbSet<Window> Windows { get; set; }

    public virtual DbSet<WindowStatus> WindowStatuses { get; set; }

    public virtual DbSet<WorkHour> WorkHours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=178.89.186.221,1434;Initial Catalog=queue_db;User ID=aybolat_user;Password=F5u!03hl9;MultipleActiveResultSets=True;Application Name=EntityFramework;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("aybolat_user");

        modelBuilder.Entity<Domain.Entity.Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Actions__FFE3F4B95219E663");

            entity.ToTable("Actions", "elec_queue");

            entity.HasIndex(e => e.Name, "UQ__Actions__737584F6BE2928EA").IsUnique();

            entity.Property(e => e.ActionId).HasColumnName("ActionID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actions_CreatedBy");
        });

        modelBuilder.Entity<ExceedingsTime>(entity =>
        {
            entity.ToTable("ExceedingsTimes", "elec_queue");

            entity.Property(e => e.ExceedingsTimeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ExceedingsTimeID");
            entity.Property(e => e.CanceledOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.WindowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WindowID");

            entity.HasOne(d => d.Window).WithMany(p => p.ExceedingsTimes)
                .HasForeignKey(d => d.WindowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExceedingsTimes_WindowID");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logs__3214EC07BA0C7C6D");

            entity.Property(e => e.Level).HasMaxLength(128);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notifications", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__Notifica__33287F950B089DC3").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__Notifica__3328B6A4ED91018E").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__Notifica__332920C2FE23F6E7").IsUnique();

            entity.Property(e => e.NotificationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("NotificationID");
            entity.Property(e => e.ContentEn).HasColumnName("Content_en");
            entity.Property(e => e.ContentKk).HasColumnName("Content_kk");
            entity.Property(e => e.ContentRu).HasColumnName("Content_ru");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");
            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.QueueTypeId).HasColumnName("QueueTypeID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_CreatedBy");

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_NotificationTypeID");

            entity.HasOne(d => d.QueueType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.QueueTypeId)
                .HasConstraintName("FK_Notifications_QueueTypes");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.NotificationTypeId).HasName("PK__Notifica__299002A12DEDBB1C");

            entity.ToTable("NotificationTypes", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__Notifica__33287F95611F9C3D").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__Notifica__3328B6A4C1CB6811").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__Notifica__332920C211D46D3B").IsUnique();

            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NotificationTypes)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationTypes_CreatedBy");
        });

        modelBuilder.Entity<QueueItem>(entity =>
        {
            entity.ToTable("QueueItems", "elec_queue");

            entity.Property(e => e.QueueItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("QueueItemID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Manager).WithMany(p => p.QueueItems)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QueueItems_ManagerID");

            entity.HasOne(d => d.Record).WithMany(p => p.QueueItems)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QueueItems_RecordID");

            entity.HasOne(d => d.Status).WithMany(p => p.QueueItems)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QueueItems_StatusID");
        });

        modelBuilder.Entity<QueueType>(entity =>
        {
            entity.ToTable("QueueTypes", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__QueueTyp__33287F958BA669A9").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__QueueTyp__3328B6A452BC55D5").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__QueueTyp__332920C2215C50F4").IsUnique();

            entity.Property(e => e.QueueTypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("QueueTypeID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.QueueTypes)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QueueTypes_CreatedBy");
        });

        modelBuilder.Entity<ReasonsForCancellation>(entity =>
        {
            entity.HasKey(e => e.ReasonId);

            entity.ToTable("ReasonsForCancellation", "elec_queue");

            entity.Property(e => e.ReasonId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReasonID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");

            entity.HasOne(d => d.Record).WithMany(p => p.ReasonsForCancellations)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReasonsForCancellation_RecordID");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK_Records_RecordID");

            entity.ToTable("Records", "elec_queue");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Iin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IIN");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ServiceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ServiceID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Records)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Records_CreatedBy");

            entity.HasOne(d => d.Service).WithMany(p => p.Records)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_ServiceID");
        });

        modelBuilder.Entity<RecordStatus>(entity =>
        {
            entity.HasKey(e => e.RecordStatusId).HasName("PK__RecordSt__964FE1443BCA69B5");

            entity.ToTable("RecordStatuses", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__RecordSt__33287F955252DF28").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__RecordSt__3328B6A47E769326").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__RecordSt__332920C2544F6D04").IsUnique();

            entity.Property(e => e.RecordStatusId).HasColumnName("RecordStatusID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RecordStatuses)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecordStatuses_CreatedBy");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1814FC37E10C2");

            entity.ToTable("Resources", "elec_queue");

            entity.HasIndex(e => e.Name, "UQ__Resource__737584F6CF75E2E0").IsUnique();

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Resources)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_CreatedBy");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews", "elec_queue");

            entity.Property(e => e.ReviewId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReviewID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");

            entity.HasOne(d => d.Record).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_RecordID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__Roles__33287F95BD5ADAF7").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__Roles__3328B6A4934F2A06").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__Roles__332920C2E2E578C2").IsUnique();

            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");
            entity.Property(e => e.QueueTypeId).HasColumnName("QueueTypeID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_CreatedBy");

            entity.HasOne(d => d.QueueType).WithMany(p => p.Roles)
                .HasForeignKey(d => d.QueueTypeId)
                .HasConstraintName("FK_Roles_QueueTypes");
        });

        modelBuilder.Entity<RoleAccess>(entity =>
        {
            entity.ToTable("RoleAccesses", "elec_queue");

            entity.Property(e => e.RoleAccessId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleAccessID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.GivenBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleID");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");

            entity.HasOne(d => d.GivenByNavigation).WithMany(p => p.RoleAccessGivenByNavigations)
                .HasForeignKey(d => d.GivenBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleAccesses_GivenBy");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleAccesses)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleAccesses_RoleID");

            entity.HasOne(d => d.User).WithMany(p => p.RoleAccessUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleAccesses_UserID");
        });

        modelBuilder.Entity<RoleResourceAction>(entity =>
        {
            entity.ToTable("RoleResourceActions", "elec_queue");

            entity.Property(e => e.RoleResourceActionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleResourceActionID");
            entity.Property(e => e.ActionId).HasColumnName("ActionID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleID");

            entity.HasOne(d => d.Action).WithMany(p => p.RoleResourceActions)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleResourceActions_ActionID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleResourceActions)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleResourceActions_CreatedBy");

            entity.HasOne(d => d.Resource).WithMany(p => p.RoleResourceActions)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleResourceActions_ResourceID");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleResourceActions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleResourceActions_RoleID");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Services", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__Services__33287F952ED4BBE2").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__Services__3328B6A4C1A6686B").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__Services__332920C2C1450A33").IsUnique();

            entity.Property(e => e.ServiceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ServiceID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");
            entity.Property(e => e.ParentserviceId).HasColumnName("ParentserviceID");
            entity.Property(e => e.QueueTypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("QueueTypeID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_CreatedBy");

            entity.HasOne(d => d.Parentservice).WithMany(p => p.InverseParentservice)
                .HasForeignKey(d => d.ParentserviceId)
                .HasConstraintName("FK_Services_ParentserviceID");

            entity.HasOne(d => d.QueueType).WithMany(p => p.Services)
                .HasForeignKey(d => d.QueueTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_QueueTypeID");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.AccessToken).HasName("PK__Tokens__1EB4F8164B04DA9B");

            entity.ToTable("Tokens", "elec_queue");

            entity.Property(e => e.AccessToken).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "elec_queue");

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.HasIndex(e => e.Login, "UQ__Users__5E55825BBAD73E33").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.QueueTypeId).HasColumnName("QueueTypeID");
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Users_CreatedBy");

            entity.HasOne(d => d.QueueType).WithMany(p => p.Users)
                .HasForeignKey(d => d.QueueTypeId)
                .HasConstraintName("FK_Users_QueueTypes");
        });

        modelBuilder.Entity<UserPhoto>(entity =>
        {
            entity.ToTable("UserPhotos", "elec_queue");

            entity.Property(e => e.UserPhotoId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserPhotoID");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserPhotos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPhotos_Users");
        });

        modelBuilder.Entity<UserService>(entity =>
        {
            entity.ToTable("UserServices", "elec_queue");

            entity.Property(e => e.UserServiceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserServiceID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ServiceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ServiceID");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserServiceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServices_CreatedBy");

            entity.HasOne(d => d.Service).WithMany(p => p.UserServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServices_ServiceID");

            entity.HasOne(d => d.User).WithMany(p => p.UserServiceUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserServices_UserID");
        });

        modelBuilder.Entity<UserWindow>(entity =>
        {
            entity.ToTable("UserWindows", "elec_queue");

            entity.Property(e => e.UserWindowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserWindowID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.WindowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WindowID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserWindowCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWindows_CreatedBy");

            entity.HasOne(d => d.User).WithMany(p => p.UserWindowUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWindows_UserID");

            entity.HasOne(d => d.Window).WithMany(p => p.UserWindows)
                .HasForeignKey(d => d.WindowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWindows_WindowID");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Videos__3214EC0737760C4E");

            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(500);
        });

        modelBuilder.Entity<Window>(entity =>
        {
            entity.ToTable("Windows", "elec_queue");

            entity.Property(e => e.WindowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WindowID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");
            entity.Property(e => e.QueueTypeId).HasColumnName("QueueTypeID");
            entity.Property(e => e.WindowStatusId).HasColumnName("WindowStatusID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Windows)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Windows_CreatedBy");

            entity.HasOne(d => d.QueueType).WithMany(p => p.Windows)
                .HasForeignKey(d => d.QueueTypeId)
                .HasConstraintName("FK_Windows_QueueTypes");

            entity.HasOne(d => d.WindowStatus).WithMany(p => p.Windows)
                .HasForeignKey(d => d.WindowStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Windows_WindowStatusID");
        });

        modelBuilder.Entity<WindowStatus>(entity =>
        {
            entity.HasKey(e => e.WindowStatusId).HasName("PK__WindowSt__830B9B2E857412DC");

            entity.ToTable("WindowStatuses", "elec_queue");

            entity.HasIndex(e => e.NameKk, "UQ__WindowSt__33287F95369BF46C").IsUnique();

            entity.HasIndex(e => e.NameRu, "UQ__WindowSt__3328B6A4B865CC11").IsUnique();

            entity.HasIndex(e => e.NameEn, "UQ__WindowSt__332920C2C97612F7").IsUnique();

            entity.Property(e => e.WindowStatusId).HasColumnName("WindowStatusID");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionEn).HasColumnName("Description_en");
            entity.Property(e => e.DescriptionKk).HasColumnName("Description_kk");
            entity.Property(e => e.DescriptionRu).HasColumnName("Description_ru");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("Name_en");
            entity.Property(e => e.NameKk)
                .HasMaxLength(100)
                .HasColumnName("Name_kk");
            entity.Property(e => e.NameRu)
                .HasMaxLength(100)
                .HasColumnName("Name_ru");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WindowStatuses)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WindowStatuses_UserID");
        });

        modelBuilder.Entity<WorkHour>(entity =>
        {
            entity.ToTable("WorkHours", "elec_queue");

            entity.Property(e => e.WorkHourId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WorkHourID");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.WorkHours)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkHours_UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
