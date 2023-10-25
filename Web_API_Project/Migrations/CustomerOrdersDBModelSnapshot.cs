﻿// <auto-generated />
using System;
using Megalon.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web_API_Project.Migrations
{
    [DbContext(typeof(CustomerOrdersDB))]
    partial class CustomerOrdersDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Megalon.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                            DOB = new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alice",
                            LastName = "Smith"
                        },
                        new
                        {
                            CustomerId = new Guid("1db7a052-91d5-43f0-8eeb-c852b504cd59"),
                            DOB = new DateTime(1986, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bob",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("Megalon.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("char(36)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            CustomerID = new Guid("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                            ItemName = "Nail Polish",
                            ItemPrice = 100.00m
                        },
                        new
                        {
                            OrderID = 2,
                            CustomerID = new Guid("481cf36a-fdb8-4911-853f-34ad26df4a2a"),
                            ItemName = "Hair Brush",
                            ItemPrice = 500.00m
                        },
                        new
                        {
                            OrderID = 3,
                            CustomerID = new Guid("1db7a052-91d5-43f0-8eeb-c852b504cd59"),
                            ItemName = "Shaving Cream",
                            ItemPrice = 90.00m
                        });
                });

            modelBuilder.Entity("Megalon.Models.Order", b =>
                {
                    b.HasOne("Megalon.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Megalon.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
