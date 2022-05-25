﻿// <auto-generated />
using System;
using AssetsManagement.DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetsManagement.DL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetsManagement.DL.Models.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AssetCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRetired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssetCategoryId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StockId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.AssetCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetCategories");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.AuditEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKeyValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PersonalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Dt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Asset", b =>
                {
                    b.HasOne("AssetsManagement.DL.Models.AssetCategory", "AssetCategory")
                        .WithMany("Assets")
                        .HasForeignKey("AssetCategoryId");

                    b.HasOne("AssetsManagement.DL.Models.Invoice", "Invoice")
                        .WithMany("Assets")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("AssetsManagement.DL.Models.Employee", "Owner")
                        .WithMany("Assets")
                        .HasForeignKey("OwnerId");

                    b.HasOne("AssetsManagement.DL.Models.Stock", "Stock")
                        .WithMany("Assets")
                        .HasForeignKey("StockId");

                    b.Navigation("AssetCategory");

                    b.Navigation("Invoice");

                    b.Navigation("Owner");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Employee", b =>
                {
                    b.HasOne("AssetsManagement.DL.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetsManagement.DL.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Department");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Invoice", b =>
                {
                    b.HasOne("AssetsManagement.DL.Models.Supplier", "Supplier")
                        .WithMany("Invoices")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.AssetCategory", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Employee", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Invoice", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Stock", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetsManagement.DL.Models.Supplier", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
