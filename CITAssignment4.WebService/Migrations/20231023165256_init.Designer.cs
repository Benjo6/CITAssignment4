﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CITAssignment4.WebService.Migrations
{
    [DbContext(typeof(CIT4DbContext))]
    [Migration("20231023165256_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("customername");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("orderid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customerid");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employeeid");

                    b.Property<decimal?>("Freight")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("freight");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("orderdate");

                    b.Property<DateTime?>("RequireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("requiredate");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("shipaddress");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("shipcity");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("shipcountry");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("shipname");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("shippostalcode");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("shippeddate");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderid");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productid");

                    b.Property<int>("Discount")
                        .HasColumnType("int")
                        .HasColumnName("discount");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unitprice");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("productid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("productname");

                    b.Property<string>("QuantityPerUnit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("quantityperunit");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("supplierid");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unitprice");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int")
                        .HasColumnName("unitsinstock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.OrderDetails", b =>
                {
                    b.HasOne("CITAssignment4.DataLayer.Domain.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CITAssignment4.DataLayer.Domain.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Product", b =>
                {
                    b.HasOne("CITAssignment4.DataLayer.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("CITAssignment4.DataLayer.Domain.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
