﻿// <auto-generated />
using System;
using LiveClinic.Billing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiveClinic.Billing.Infrastructure.Migrations
{
    [DbContext(typeof(BillingDbContext))]
    [Migration("20210728224218_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.InvoiceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PriceCatalogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiptNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.PriceAggregate.PriceCatalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DrugCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PriceCatalogs");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.InvoiceItem", b =>
                {
                    b.HasOne("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Invoice", null)
                        .WithMany("Items")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LiveClinic.Billing.Core.Domain.Common.Money", "QuotePrice", b1 =>
                        {
                            b1.Property<Guid>("InvoiceItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float")
                                .HasColumnName("QuotePrice");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("InvoiceItemId");

                            b1.ToTable("InvoiceItems");

                            b1.WithOwner()
                                .HasForeignKey("InvoiceItemId");
                        });

                    b.Navigation("QuotePrice");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Payment", b =>
                {
                    b.HasOne("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Invoice", null)
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LiveClinic.Billing.Core.Domain.Common.Money", "AmountPaid", b1 =>
                        {
                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float")
                                .HasColumnName("AmountPaid");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payments");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.Navigation("AmountPaid");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.PriceAggregate.PriceCatalog", b =>
                {
                    b.OwnsOne("LiveClinic.Billing.Core.Domain.Common.Money", "UnitPrice", b1 =>
                        {
                            b1.Property<Guid>("PriceCatalogId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float")
                                .HasColumnName("UnitPrice");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("PriceCatalogId");

                            b1.ToTable("PriceCatalogs");

                            b1.WithOwner()
                                .HasForeignKey("PriceCatalogId");
                        });

                    b.Navigation("UnitPrice");
                });

            modelBuilder.Entity("LiveClinic.Billing.Core.Domain.InvoiceAggregate.Invoice", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}