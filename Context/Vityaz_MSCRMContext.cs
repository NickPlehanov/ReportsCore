﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReportsCore.Models;

namespace ReportsCore
{
    public partial class Vityaz_MSCRMContext : DbContext
    {
        public Vityaz_MSCRMContext()
        {
        }

        public Vityaz_MSCRMContext(DbContextOptions<Vityaz_MSCRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountBase> AccountBase { get; set; }
        public virtual DbSet<AccountExtensionBase> AccountExtensionBase { get; set; }
        public virtual DbSet<NewAgreementBase> NewAgreementBase { get; set; }
        public virtual DbSet<NewAgreementExtensionBase> NewAgreementExtensionBase { get; set; }
        public virtual DbSet<NewAlarmBase> NewAlarmBase { get; set; }
        public virtual DbSet<NewAlarmExtensionBase> NewAlarmExtensionBase { get; set; }
        public virtual DbSet<NewAndromedaBase> NewAndromedaBase { get; set; }
        public virtual DbSet<NewAndromedaExtensionBase> NewAndromedaExtensionBase { get; set; }
        public virtual DbSet<NewDogovorTypeBase> NewDogovorTypeBase { get; set; }
        public virtual DbSet<NewDogovorTypeExtensionBase> NewDogovorTypeExtensionBase { get; set; }
        public virtual DbSet<NewExecutorExtensionBase> NewExecutorExtensionBase { get; set; }
        public virtual DbSet<NewGuardObjectBase> NewGuardObjectBase { get; set; }
        public virtual DbSet<NewGuardObjectExtensionBase> NewGuardObjectExtensionBase { get; set; }
        public virtual DbSet<NewGuardObjectHistory> NewGuardObjectHistory { get; set; }
        public virtual DbSet<NewNewAgreementNewGuardObjectBase> NewNewAgreementNewGuardObjectBase { get; set; }
        public virtual DbSet<SystemUserBase> SystemUserBase { get; set; }
        public virtual DbSet<SystemUserExtensionBase> SystemUserExtensionBase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sql-service;Database=vityaz_MSCRM;Persist Security Info=True;User ID=admin;Password=111111;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountBase>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("cndx_PrimaryKey_Account");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("ndx_Account_AccountNumber");

                entity.HasIndex(e => e.DefaultPriceLevelId)
                    .HasName("ndx_for_cascaderelationship_price_level_accounts");

                entity.HasIndex(e => e.EmailAddress1)
                    .HasName("ndx_Email_1");

                entity.HasIndex(e => e.EmailAddress2)
                    .HasName("ndx_Email_2");

                entity.HasIndex(e => e.EmailAddress3)
                    .HasName("ndx_Email_3");

                entity.HasIndex(e => e.MasterId)
                    .HasName("ndx_for_cascaderelationship_account_master_account");

                entity.HasIndex(e => e.Name)
                    .HasName("ndx_Account_Name");

                entity.HasIndex(e => e.OriginatingLeadId)
                    .HasName("ndx_for_cascaderelationship_account_originating_lead");

                entity.HasIndex(e => e.ParentAccountId)
                    .HasName("ndx_for_cascaderelationship_account_parent_account");

                entity.HasIndex(e => e.PreferredEquipmentId)
                    .HasName("ndx_for_cascaderelationship_equipment_accounts");

                entity.HasIndex(e => e.PreferredServiceId)
                    .HasName("ndx_for_cascaderelationship_service_accounts");

                entity.HasIndex(e => e.PreferredSystemUserId)
                    .HasName("ndx_for_cascaderelationship_system_user_accounts");

                entity.HasIndex(e => e.PrimaryContactId)
                    .HasName("ndx_for_cascaderelationship_account_primary_contact");

                entity.HasIndex(e => e.TerritoryId)
                    .HasName("ndx_for_cascaderelationship_territory_accounts");

                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync_VersionNumber")
                    .IsUnique();

                entity.HasIndex(e => new { e.OwningUser, e.OwningBusinessUnit })
                    .HasName("ndx_Security");

                entity.HasIndex(e => new { e.DeletionStateCode, e.StateCode, e.StatusCode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.DoNotBulkEmail).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotBulkPostalMail).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotEmail).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotFax).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotPhone).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotPostalMail).HasDefaultValueSql("((0))");

                entity.Property(e => e.DoNotSendMm).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrivate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Merged).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParticipatesInWorkflow).HasDefaultValueSql("((0))");

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.InverseMaster)
                    .HasForeignKey(d => d.MasterId)
                    .HasConstraintName("account_master_account");

                entity.HasOne(d => d.OwningUserNavigation)
                    .WithMany(p => p.AccountBaseOwningUserNavigation)
                    .HasForeignKey(d => d.OwningUser)
                    .HasConstraintName("user_accounts");

                entity.HasOne(d => d.ParentAccount)
                    .WithMany(p => p.InverseParentAccount)
                    .HasForeignKey(d => d.ParentAccountId)
                    .HasConstraintName("account_parent_account");

                entity.HasOne(d => d.PreferredSystemUser)
                    .WithMany(p => p.AccountBasePreferredSystemUser)
                    .HasForeignKey(d => d.PreferredSystemUserId)
                    .HasConstraintName("system_user_accounts");
            });

            modelBuilder.Entity<AccountExtensionBase>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.HasOne(d => d.NewDebitorOwnerNavigation)
                    .WithMany(p => p.AccountExtensionBase)
                    .HasForeignKey(d => d.NewDebitorOwner)
                    .HasConstraintName("new_debitor_systemuser_account");
            });

            modelBuilder.Entity<NewAgreementBase>(entity =>
            {
                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.OwningUser, e.OwningBusinessUnit })
                    .HasName("ndx_Security");

                entity.HasIndex(e => new { e.DeletionStateCode, e.Statecode, e.Statuscode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.NewAgreementId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OwningUserNavigation)
                    .WithMany(p => p.NewAgreementBase)
                    .HasForeignKey(d => d.OwningUser)
                    .HasConstraintName("user_new_agreement");
            });

            modelBuilder.Entity<NewAgreementExtensionBase>(entity =>
            {
                entity.HasIndex(e => e.NewBpAgreement)
                    .HasName("ndx_for_cascaderelationship_new_account_agreement");

                entity.Property(e => e.NewAgreementId).ValueGeneratedNever();

                entity.HasOne(d => d.NewAgreementNavigation)
                    .WithMany(p => p.NewAgreementExtensionBase)
                    .HasForeignKey(d => d.NewAgreement)
                    .HasConstraintName("new_new_guard_object_agreement");

                entity.HasOne(d => d.NewAgreement1)
                    .WithOne(p => p.NewAgreementExtensionBase)
                    .HasForeignKey<NewAgreementExtensionBase>(d => d.NewAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_New_agreementExtensionBase_New_agreementBase");

                entity.HasOne(d => d.NewBpAgreementNavigation)
                    .WithMany(p => p.NewAgreementExtensionBase)
                    .HasForeignKey(d => d.NewBpAgreement)
                    .HasConstraintName("new_account_agreement");

                entity.HasOne(d => d.NewDogovorTypeAgreementNavigation)
                    .WithMany(p => p.NewAgreementExtensionBase)
                    .HasForeignKey(d => d.NewDogovorTypeAgreement)
                    .HasConstraintName("new_dogovor_type_agreement");
            });

            modelBuilder.Entity<NewAlarmBase>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId)
                    .HasName("ndx_Security");

                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.DeletionStateCode, e.Statecode, e.Statuscode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.NewAlarmId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<NewAlarmExtensionBase>(entity =>
            {
                entity.Property(e => e.NewAlarmId).ValueGeneratedNever();

                entity.HasOne(d => d.NewAlarm)
                    .WithOne(p => p.NewAlarmExtensionBase)
                    .HasForeignKey<NewAlarmExtensionBase>(d => d.NewAlarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_New_alarmExtensionBase_New_alarmBase");

                entity.HasOne(d => d.NewAndromedaAlarmNavigation)
                    .WithMany(p => p.NewAlarmExtensionBase)
                    .HasForeignKey(d => d.NewAndromedaAlarm)
                    .HasConstraintName("new_andromeda_alarm");
            });

            modelBuilder.Entity<NewAndromedaBase>(entity =>
            {
                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.OwningUser, e.OwningBusinessUnit })
                    .HasName("ndx_Security");

                entity.HasIndex(e => new { e.DeletionStateCode, e.Statecode, e.Statuscode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.NewAndromedaId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OwningUserNavigation)
                    .WithMany(p => p.NewAndromedaBase)
                    .HasForeignKey(d => d.OwningUser)
                    .HasConstraintName("user_new_andromeda");
            });

            modelBuilder.Entity<NewAndromedaExtensionBase>(entity =>
            {
                entity.HasIndex(e => e.NewContactAndromeda)
                    .HasName("ndx_for_cascaderelationship_new_contact_new_andromeda");

                entity.Property(e => e.NewAndromedaId).ValueGeneratedNever();

                entity.HasOne(d => d.NewAndromeda)
                    .WithOne(p => p.NewAndromedaExtensionBase)
                    .HasForeignKey<NewAndromedaExtensionBase>(d => d.NewAndromedaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_New_andromedaExtensionBase_New_andromedaBase");

                entity.HasOne(d => d.NewPostNavigation)
                    .WithMany(p => p.NewAndromedaExtensionBase)
                    .HasForeignKey(d => d.NewPost)
                    .HasConstraintName("new_new_alarm_new_andromeda");
            });

            modelBuilder.Entity<NewDogovorTypeBase>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId)
                    .HasName("ndx_Security");

                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.DeletionStateCode, e.Statecode, e.Statuscode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.NewDogovorTypeId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<NewDogovorTypeExtensionBase>(entity =>
            {
                entity.Property(e => e.NewDogovorTypeId).ValueGeneratedNever();

                entity.HasOne(d => d.NewDogovorType)
                    .WithOne(p => p.NewDogovorTypeExtensionBase)
                    .HasForeignKey<NewDogovorTypeExtensionBase>(d => d.NewDogovorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_New_dogovor_typeExtensionBase_New_dogovor_typeBase");
            });

            modelBuilder.Entity<NewExecutorExtensionBase>(entity =>
            {
                entity.Property(e => e.NewExecutorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<NewGuardObjectBase>(entity =>
            {
                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.OwningUser, e.OwningBusinessUnit })
                    .HasName("ndx_Security");

                entity.HasIndex(e => new { e.DeletionStateCode, e.Statecode, e.Statuscode })
                    .HasName("ndx_Core");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.NewGuardObjectId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OwningUserNavigation)
                    .WithMany(p => p.NewGuardObjectBase)
                    .HasForeignKey(d => d.OwningUser)
                    .HasConstraintName("user_new_guard_object");
            });

            modelBuilder.Entity<NewGuardObjectExtensionBase>(entity =>
            {
                entity.HasIndex(e => e.NewAccount)
                    .HasName("ndx_for_cascaderelationship_new_account_new_guard_object");

                entity.HasIndex(e => e.NewAccountAgent)
                    .HasName("ndx_for_cascaderelationship_new_account_agent_new_guard_object");

                entity.HasIndex(e => e.NewContact)
                    .HasName("ndx_for_cascaderelationship_new_contact_new_guard_object");

                entity.HasIndex(e => e.NewReactionAccount)
                    .HasName("ndx_for_cascaderelationship_new_account_new_guard_object_reaction");

                entity.HasIndex(e => e.NewTechserviceAccount)
                    .HasName("ndx_for_cascaderelationship_new_account_new_guard_object_techservice");

                entity.HasIndex(e => e.NewUvoUnit)
                    .HasName("ndx_for_cascaderelationship_new_account_new_guard_object_uvo_unit");

                entity.Property(e => e.NewGuardObjectId).ValueGeneratedNever();

                entity.HasOne(d => d.NewAccountNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewAccountNavigation)
                    .HasForeignKey(d => d.NewAccount)
                    .HasConstraintName("new_account_new_guard_object");

                entity.HasOne(d => d.NewAccountAgentNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewAccountAgentNavigation)
                    .HasForeignKey(d => d.NewAccountAgent)
                    .HasConstraintName("new_account_agent_new_guard_object");

                entity.HasOne(d => d.NewCuratorNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewCuratorNavigation)
                    .HasForeignKey(d => d.NewCurator)
                    .HasConstraintName("new_systemuser_new_guard_object");

                entity.HasOne(d => d.NewCuratorMountNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewCuratorMountNavigation)
                    .HasForeignKey(d => d.NewCuratorMount)
                    .HasConstraintName("new_new_guard_object_new_guard_object");

                entity.HasOne(d => d.NewCuratorUserMountNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewCuratorUserMountNavigation)
                    .HasForeignKey(d => d.NewCuratorUserMount)
                    .HasConstraintName("new_systemuser_new_guard_object_mount");

                entity.HasOne(d => d.NewGuardObject)
                    .WithOne(p => p.NewGuardObjectExtensionBaseNewGuardObject)
                    .HasForeignKey<NewGuardObjectExtensionBase>(d => d.NewGuardObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_New_guard_objectExtensionBase_New_guard_objectBase");

                entity.HasOne(d => d.NewInspectorNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewInspectorNavigation)
                    .HasForeignKey(d => d.NewInspector)
                    .HasConstraintName("new_systemuser_guard_object");

                entity.HasOne(d => d.NewReactionAccountNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewReactionAccountNavigation)
                    .HasForeignKey(d => d.NewReactionAccount)
                    .HasConstraintName("new_account_new_guard_object_reaction");

                entity.HasOne(d => d.NewRetentionNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewRetentionNavigation)
                    .HasForeignKey(d => d.NewRetention)
                    .HasConstraintName("new_systemuser_retention_new_guard_object");

                entity.HasOne(d => d.NewTechserviceAccountNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewTechserviceAccountNavigation)
                    .HasForeignKey(d => d.NewTechserviceAccount)
                    .HasConstraintName("new_account_new_guard_object_techservice");

                entity.HasOne(d => d.NewUvoUnitNavigation)
                    .WithMany(p => p.NewGuardObjectExtensionBaseNewUvoUnitNavigation)
                    .HasForeignKey(d => d.NewUvoUnit)
                    .HasConstraintName("new_account_new_guard_object_uvo_unit");
            });

            modelBuilder.Entity<NewGuardObjectHistory>(entity =>
            {
                entity.HasKey(e => e.ModifiedOn)
                    .HasName("PK_ModifiedOn");
            });

            modelBuilder.Entity<NewNewAgreementNewGuardObjectBase>(entity =>
            {
                entity.HasIndex(e => e.NewAgreementid)
                    .HasName("ndx_new_agreementid");

                entity.HasIndex(e => e.NewGuardObjectid)
                    .HasName("ndx_new_guard_objectid");

                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync");

                entity.HasIndex(e => new { e.NewAgreementid, e.NewGuardObjectid })
                    .HasName("ndx_new_new_agreement_new_guard_object")
                    .IsUnique();

                entity.Property(e => e.NewNewAgreementNewGuardObjectId).ValueGeneratedNever();

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.NewAgreement)
                    .WithMany(p => p.NewNewAgreementNewGuardObjectBase)
                    .HasForeignKey(d => d.NewAgreementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("new_new_agreement_new_guard_objectOne");

                entity.HasOne(d => d.NewGuardObject)
                    .WithMany(p => p.NewNewAgreementNewGuardObjectBase)
                    .HasForeignKey(d => d.NewGuardObjectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("new_new_agreement_new_guard_objectTwo");
            });

            modelBuilder.Entity<SystemUserBase>(entity =>
            {
                entity.HasKey(e => e.SystemUserId)
                    .HasName("cndx_PrimaryKey_SystemUser");

                entity.HasIndex(e => e.ActiveDirectoryGuid)
                    .HasName("UQ_SystemUserBaseActiveDirectoryGuid")
                    .IsUnique();

                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("ndx_Security");

                entity.HasIndex(e => e.CalendarId)
                    .HasName("ndx_for_cascaderelationship_calendar_system_users");

                entity.HasIndex(e => e.DeletionStateCode)
                    .HasName("ndx_Core");

                entity.HasIndex(e => e.InternalEmailAddress)
                    .HasName("ndx_Email_1");

                entity.HasIndex(e => e.MobileAlertEmail)
                    .HasName("ndx_Email_3");

                entity.HasIndex(e => e.ParentSystemUserId)
                    .HasName("ndx_for_cascaderelationship_user_parent_user");

                entity.HasIndex(e => e.PersonalEmailAddress)
                    .HasName("ndx_Email_2");

                entity.HasIndex(e => e.SiteId)
                    .HasName("ndx_for_cascaderelationship_site_system_users");

                entity.HasIndex(e => e.TerritoryId)
                    .HasName("ndx_for_cascaderelationship_territory_system_users");

                entity.HasIndex(e => e.VersionNumber)
                    .HasName("ndx_Sync_VersionNumber")
                    .IsUnique();

                entity.HasIndex(e => new { e.FullName, e.YomiFullName })
                    .HasName("ndx_Cover");

                entity.HasIndex(e => new { e.CreatedBy, e.CreatedOn, e.ModifiedBy, e.ModifiedOn })
                    .HasName("ndx_Auditing");

                entity.Property(e => e.SystemUserId).ValueGeneratedNever();

                entity.Property(e => e.IncomingEmailDeliveryMethod).HasDefaultValueSql("((1))");

                entity.Property(e => e.InviteStatusCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActiveDirectoryUser).HasDefaultValueSql("((1))");

                entity.Property(e => e.OutgoingEmailDeliveryMethod).HasDefaultValueSql("((1))");

                entity.Property(e => e.VersionNumber)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ParentSystemUser)
                    .WithMany(p => p.InverseParentSystemUser)
                    .HasForeignKey(d => d.ParentSystemUserId)
                    .HasConstraintName("user_parent_user");
            });

            modelBuilder.Entity<SystemUserExtensionBase>(entity =>
            {
                entity.Property(e => e.SystemUserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}