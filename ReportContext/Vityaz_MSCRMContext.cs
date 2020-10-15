﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReportsCore.Context;
using ReportsCore.ReportBaseModels;

namespace ReportsCore.ReportContext
{
    public partial class ReportContext : DbContext
    {
        public ReportContext()
        {
        }

        public ReportContext(DbContextOptions<Vityaz_MSCRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<UsersReports> UsersReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.28;Initial Catalog=ReportBase;Persist Security Info=True;User ID=sa;Password=Qwerty_12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reports>(entity =>
            {
                entity.Property(e => e.RptId).ValueGeneratedNever();
            });

            modelBuilder.Entity<UsersReports>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}