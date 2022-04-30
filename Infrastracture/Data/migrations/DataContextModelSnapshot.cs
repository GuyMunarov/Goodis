﻿// <auto-generated />
using System;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastracture.Data.migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Models.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Entities.BpType", b =>
                {
                    b.Property<string>("TypeCode")
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("TypeCode");

                    b.ToTable("BpTypes");
                });

            modelBuilder.Entity("Models.Entities.BusinessPartner", b =>
                {
                    b.Property<string>("BpCode")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BPName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BpTypeTypeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BpCode");

                    b.HasIndex("BpTypeTypeCode");

                    b.ToTable("BusinessPartners");
                });

            modelBuilder.Entity("Models.Entities.Item", b =>
                {
                    b.Property<string>("ItemCode")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.HasKey("ItemCode");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Models.Entities.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BpCode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LastUpdatedById")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BpCode");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("Models.Entities.PurchaseOrderLine", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LastUpdatedById")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Quantity")
                        .HasColumnType("decimal(38,18)");

                    b.HasKey("LineID");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DocID");

                    b.HasIndex("ItemCode");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("PurchaseOrderLines");
                });

            modelBuilder.Entity("Models.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BpCode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LastUpdatedById")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BpCode");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("Models.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LastUpdatedById")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Quantity")
                        .HasColumnType("decimal(38,18)");

                    b.HasKey("LineID");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DocID");

                    b.HasIndex("ItemCode");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("Models.Entities.SalesOrderLineComment", b =>
                {
                    b.Property<int?>("CommentLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DocId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentLineID");

                    b.HasIndex("DocId");

                    b.HasIndex("LineID");

                    b.ToTable("SaleOrderLinesComments");
                });

            modelBuilder.Entity("Models.Entities.BusinessPartner", b =>
                {
                    b.HasOne("Models.Entities.BpType", "BpType")
                        .WithMany("BusinessPartners")
                        .HasForeignKey("BpTypeTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BpType");
                });

            modelBuilder.Entity("Models.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("Models.Entities.BusinessPartner", "BusinessPartner")
                        .WithMany()
                        .HasForeignKey("BpCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "CreatedBy")
                        .WithMany("PurchaseOrdersCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "LastUpdatedBy")
                        .WithMany("PurchaseOrdersUpdated")
                        .HasForeignKey("LastUpdatedById");

                    b.Navigation("BusinessPartner");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Models.Entities.PurchaseOrderLine", b =>
                {
                    b.HasOne("Models.Entities.AppUser", "CreatedBy")
                        .WithMany("PurchaseOrderLines")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.PurchaseOrder", "Document")
                        .WithMany()
                        .HasForeignKey("DocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("Document");

                    b.Navigation("Item");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Models.Entities.SaleOrder", b =>
                {
                    b.HasOne("Models.Entities.BusinessPartner", "BusinessPartner")
                        .WithMany()
                        .HasForeignKey("BpCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "CreatedBy")
                        .WithMany("SaleOrdersCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "LastUpdatedBy")
                        .WithMany("SaleOrdersUpdated")
                        .HasForeignKey("LastUpdatedById");

                    b.Navigation("BusinessPartner");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Models.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("Models.Entities.AppUser", "CreatedBy")
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.SaleOrder", "Document")
                        .WithMany()
                        .HasForeignKey("DocID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.AppUser", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("Document");

                    b.Navigation("Item");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Models.Entities.SalesOrderLineComment", b =>
                {
                    b.HasOne("Models.Entities.SaleOrder", "Doc")
                        .WithMany()
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.SaleOrderLine", "Line")
                        .WithMany()
                        .HasForeignKey("LineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doc");

                    b.Navigation("Line");
                });

            modelBuilder.Entity("Models.Entities.AppUser", b =>
                {
                    b.Navigation("PurchaseOrderLines");

                    b.Navigation("PurchaseOrdersCreated");

                    b.Navigation("PurchaseOrdersUpdated");

                    b.Navigation("SaleOrderLines");

                    b.Navigation("SaleOrdersCreated");

                    b.Navigation("SaleOrdersUpdated");
                });

            modelBuilder.Entity("Models.Entities.BpType", b =>
                {
                    b.Navigation("BusinessPartners");
                });
#pragma warning restore 612, 618
        }
    }
}
