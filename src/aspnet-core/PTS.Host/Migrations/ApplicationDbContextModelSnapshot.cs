﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PTS.EntityFrameworkCore;

#nullable disable

namespace PTS.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PTS.Domain.Entities.BillDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeProductDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillEntityId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("PTS.Domain.Entities.BillEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("InvoiceCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPayment")
                        .HasColumnType("bit");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("VoucherEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("VoucherEntityId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CardVGAEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ma")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThongSo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CardVGA");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CartDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartEntityIdUser")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductDetailEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartEntityIdUser");

                    b.HasIndex("ProductDetailEntityId");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CartEntity", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdUser");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ColorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeManagePost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CpuEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ma")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CPU");
                });

            modelBuilder.Entity("PTS.Domain.Entities.HardDriveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ma")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ThongSo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("HardDrive");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LinkImage")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductDetailEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailEntityId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ManagePostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LinkImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ManagePost");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CardVGAEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ColorEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("CpuEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HardDriveEntityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("RamEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("ScreenEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Upgrade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardVGAEntityId");

                    b.HasIndex("ColorEntityId");

                    b.HasIndex("CpuEntityId");

                    b.HasIndex("HardDriveEntityId");

                    b.HasIndex("ProductEntityId");

                    b.HasIndex("RamEntityId");

                    b.HasIndex("ScreenEntityId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ManufacturerEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ProductTypeEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerEntityId");

                    b.HasIndex("ProductTypeEntityId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("PTS.Domain.Entities.RamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ThongSo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Ram");
                });

            modelBuilder.Entity("PTS.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ScreenEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChatLieu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("KichCo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TanSo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Screen");
                });

            modelBuilder.Entity("PTS.Domain.Entities.SerialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BillDetailEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductDetailEntityId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillDetailEntityId");

                    b.HasIndex("ProductDetailEntityId");

                    b.ToTable("Serial");
                });

            modelBuilder.Entity("PTS.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdRole")
                        .HasColumnType("int");

                    b.Property<int?>("IdRoleEntity")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PTS.Domain.Entities.VoucherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GiaTri")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MaVoucher")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StarDay")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenVoucher")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("PTS.Domain.Entities.BillDetailEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.BillEntity", "BillEntity")
                        .WithMany("BillDetailEntities")
                        .HasForeignKey("BillEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.BillEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId");

                    b.HasOne("PTS.Domain.Entities.VoucherEntity", "VoucherEntitity")
                        .WithMany("BillEntities")
                        .HasForeignKey("VoucherEntityId");

                    b.Navigation("UserEntity");

                    b.Navigation("VoucherEntitity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CartDetailEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.CartEntity", "CartEntity")
                        .WithMany("CartDetailEntities")
                        .HasForeignKey("CartEntityIdUser");

                    b.HasOne("PTS.Domain.Entities.ProductDetailEntity", "ProductDetailEntity")
                        .WithMany("CartDetailEntities")
                        .HasForeignKey("ProductDetailEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartEntity");

                    b.Navigation("ProductDetailEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CartEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.UserEntity", "UserEntity")
                        .WithOne("Cart")
                        .HasForeignKey("PTS.Domain.Entities.CartEntity", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ImageEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.ProductDetailEntity", "ProductDetailEntity")
                        .WithMany("ImageEntities")
                        .HasForeignKey("ProductDetailEntityId");

                    b.Navigation("ProductDetailEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductDetailEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.CardVGAEntity", "CardVGAEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("CardVGAEntityId");

                    b.HasOne("PTS.Domain.Entities.ColorEntity", "ColorEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("ColorEntityId");

                    b.HasOne("PTS.Domain.Entities.CpuEntity", "CpuEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("CpuEntityId");

                    b.HasOne("PTS.Domain.Entities.HardDriveEntity", "HardDriveEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("HardDriveEntityId");

                    b.HasOne("PTS.Domain.Entities.ProductEntity", "ProductEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("ProductEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTS.Domain.Entities.RamEntity", "RamEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("RamEntityId");

                    b.HasOne("PTS.Domain.Entities.ScreenEntity", "ScreenEntity")
                        .WithMany("ProductDetailEntities")
                        .HasForeignKey("ScreenEntityId");

                    b.Navigation("CardVGAEntity");

                    b.Navigation("ColorEntity");

                    b.Navigation("CpuEntity");

                    b.Navigation("HardDriveEntity");

                    b.Navigation("ProductEntity");

                    b.Navigation("RamEntity");

                    b.Navigation("ScreenEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.ManufacturerEntity", "ManufacturerEntity")
                        .WithMany("ProductEntities")
                        .HasForeignKey("ManufacturerEntityId");

                    b.HasOne("PTS.Domain.Entities.ProductTypeEntity", "ProductTypeEntity")
                        .WithMany("ProductEntities")
                        .HasForeignKey("ProductTypeEntityId");

                    b.Navigation("ManufacturerEntity");

                    b.Navigation("ProductTypeEntity");
                });

            modelBuilder.Entity("PTS.Domain.Entities.SerialEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.BillDetailEntity", "BillDetailEntities")
                        .WithMany("SerialEntities")
                        .HasForeignKey("BillDetailEntityId");

                    b.HasOne("PTS.Domain.Entities.ProductDetailEntity", "ProductDetailEntities")
                        .WithMany("SerialEntities")
                        .HasForeignKey("ProductDetailEntityId");

                    b.Navigation("BillDetailEntities");

                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("PTS.Domain.Entities.RoleEntity", "RoleEntities")
                        .WithMany("UserEntities")
                        .HasForeignKey("IdRole");

                    b.Navigation("RoleEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.BillDetailEntity", b =>
                {
                    b.Navigation("SerialEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.BillEntity", b =>
                {
                    b.Navigation("BillDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CardVGAEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CartEntity", b =>
                {
                    b.Navigation("CartDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ColorEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.CpuEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.HardDriveEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("ProductEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductDetailEntity", b =>
                {
                    b.Navigation("CartDetailEntities");

                    b.Navigation("ImageEntities");

                    b.Navigation("SerialEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ProductTypeEntity", b =>
                {
                    b.Navigation("ProductEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.RamEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("UserEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.ScreenEntity", b =>
                {
                    b.Navigation("ProductDetailEntities");
                });

            modelBuilder.Entity("PTS.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Cart");
                });

            modelBuilder.Entity("PTS.Domain.Entities.VoucherEntity", b =>
                {
                    b.Navigation("BillEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
