﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApp.Infrustructure.Persistence;

#nullable disable

namespace ShopApp.Infrustructure.Migrations
{
    [DbContext(typeof(ShopAppDbContext))]
    partial class ShopAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ShopApp.Domain.BuyerAggregate.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("BuyerId");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Buyers", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.CategoryAggregate.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("OrderId");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("TEXT")
                        .HasColumnName("BuyerId");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("ProductId");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.TagAggregate.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("TagId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("UserId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ShopApp.Domain.BuyerAggregate.Buyer", b =>
                {
                    b.OwnsMany("ShopApp.Domain.OrderAggregate.ValueObjects.OrderId", "OrderIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("BuyerId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("OrderId");

                            b1.HasKey("Id");

                            b1.HasIndex("BuyerId");

                            b1.ToTable("BuyerOrderIds", (string)null);

                            // b1.HasDiscriminator().HasValue("OrderId");

                            b1.WithOwner()
                                .HasForeignKey("BuyerId");
                        });

                    b.Navigation("OrderIds");
                });

            modelBuilder.Entity("ShopApp.Domain.CategoryAggregate.Category", b =>
                {
                    b.OwnsMany("ShopApp.Domain.ProductAggregate.ValueObjects.ProductId", "ProductIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("ProductId");

                            b1.HasKey("Id");

                            b1.HasIndex("CategoryId");

                            b1.ToTable("CategoryProductIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("ProductIds");
                });

            modelBuilder.Entity("ShopApp.Domain.OrderAggregate.Order", b =>
                {
                    b.OwnsMany("ShopApp.Domain.OrderAggregate.ValueObjects.OrderItemId", "OrderItemIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("OrderItemId");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderOrderItemIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("ShopApp.Domain.OrderAggregate.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Code")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("OrderItemIds");
                });

            modelBuilder.Entity("ShopApp.Domain.ProductAggregate.Product", b =>
                {
                    b.OwnsMany("ShopApp.Domain.OrderAggregate.ValueObjects.OrderItemId", "OrderItemIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("OrderItemId");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("ProductOrderItemIdIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("ShopApp.Domain.TagAggregate.ValueObjects.TagId", "TagIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("TagId");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("ProductTagIds", (string)null);

                            // b1.HasDiscriminator().HasValue("TagId");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("OrderItemIds");

                    b.Navigation("TagIds");
                });

            modelBuilder.Entity("ShopApp.Domain.TagAggregate.Tag", b =>
                {
                    b.OwnsMany("ShopApp.Domain.ProductAggregate.ValueObjects.ProductId", "ProductIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("TagId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("ProductId");

                            b1.HasKey("Id");

                            b1.HasIndex("TagId");

                            b1.ToTable("TagProductIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TagId");
                        });

                    b.Navigation("ProductIds");
                });
#pragma warning restore 612, 618
        }
    }
}
