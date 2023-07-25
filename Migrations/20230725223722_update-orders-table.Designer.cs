﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tech_store.DbModels;

#nullable disable

namespace tech_store.Migrations
{
    [DbContext(typeof(TechStoreContext))]
    [Migration("20230725223722_update-orders-table")]
    partial class updateorderstable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tech_store.DbModels.Auth.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<string>("postal_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("target_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("target_surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.Role", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Brand", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.City", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("country_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("country_id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Country", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Model", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("brand_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("brand_id");

                    b.ToTable("models");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.ProductType", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("product_types");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("delivery_address_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiration_date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("is_book")
                        .HasColumnType("bit");

                    b.Property<int>("order_items_id")
                        .HasColumnType("int");

                    b.Property<int>("owner_id")
                        .HasColumnType("int");

                    b.Property<bool>("pass_in_branch")
                        .HasColumnType("bit");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("delivery_address_id");

                    b.HasIndex("order_items_id");

                    b.HasIndex("owner_id");

                    b.HasIndex("product_id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("owner_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("owner_id");

                    b.ToTable("order_items");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("buying_cost")
                        .HasColumnType("int");

                    b.Property<int>("creator_id")
                        .HasColumnType("int");

                    b.Property<string>("features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("initial_quantity")
                        .HasColumnType("int");

                    b.Property<int>("model_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("on_sale")
                        .HasColumnType("bit");

                    b.Property<int>("product_type_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("selling_cost")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("creator_id");

                    b.HasIndex("product_type_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.Address", b =>
                {
                    b.HasOne("tech_store.DbModels.Auth.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("tech_store.DbModels.Auth.Address", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.User", b =>
                {
                    b.HasOne("tech_store.DbModels.Auth.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.City", b =>
                {
                    b.HasOne("tech_store.DbModels.Catalogs.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Model", b =>
                {
                    b.HasOne("tech_store.DbModels.Catalogs.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("brand_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.Order", b =>
                {
                    b.HasOne("tech_store.DbModels.Auth.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("delivery_address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tech_store.DbModels.Products.OrderItem", "OrderItem")
                        .WithMany("Orders")
                        .HasForeignKey("order_items_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("tech_store.DbModels.Auth.User", "user")
                        .WithMany("Orders")
                        .HasForeignKey("owner_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("tech_store.DbModels.Products.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("OrderItem");

                    b.Navigation("Product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.OrderItem", b =>
                {
                    b.HasOne("tech_store.DbModels.Auth.User", "User")
                        .WithMany("OrderItems")
                        .HasForeignKey("owner_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.Product", b =>
                {
                    b.HasOne("tech_store.DbModels.Auth.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("creator_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tech_store.DbModels.Catalogs.Model", "Model")
                        .WithMany("Products")
                        .HasForeignKey("product_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tech_store.DbModels.Catalogs.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("product_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("ProductType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("tech_store.DbModels.Auth.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("OrderItems");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.Model", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("tech_store.DbModels.Catalogs.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.OrderItem", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("tech_store.DbModels.Products.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
