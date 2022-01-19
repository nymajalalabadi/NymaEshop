﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NymaEshop2.Data;

namespace NymaEshop2.Migrations
{
    [DbContext(typeof(MyEshopContext))]
    [Migration("20211112090130_AddKeyCategorytoproduct")]
    partial class AddKeyCategorytoproduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NymaEshop2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DesvriptionCT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesvriptionCT = "Asp.Net Core 3",
                            NameCT = "Asp.Net Core"
                        },
                        new
                        {
                            Id = 2,
                            DesvriptionCT = "گروه لباس ورزشی",
                            NameCT = "لباس ورزشی"
                        },
                        new
                        {
                            Id = 3,
                            DesvriptionCT = "گروه ساعت مچی",
                            NameCT = "ساعت مچی"
                        },
                        new
                        {
                            Id = 4,
                            DesvriptionCT = "گروه لوازم منزل",
                            NameCT = "لوازم منزل"
                        });
                });

            modelBuilder.Entity("NymaEshop2.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("Categoryid")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.HasKey("Categoryid", "Productid");

                    b.HasIndex("Productid");

                    b.ToTable("CategoryToProducts");
                });

            modelBuilder.Entity("NymaEshop2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PriceIT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NymaEshop2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionPD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("NamePD")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemID")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NymaEshop2.Models.CategoryToProduct", b =>
                {
                    b.HasOne("NymaEshop2.Models.Category", "Category")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NymaEshop2.Models.Product", "Product")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NymaEshop2.Models.Product", b =>
                {
                    b.HasOne("NymaEshop2.Models.Item", "Item")
                        .WithOne("product")
                        .HasForeignKey("NymaEshop2.Models.Product", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("NymaEshop2.Models.Category", b =>
                {
                    b.Navigation("CategoryToProducts");
                });

            modelBuilder.Entity("NymaEshop2.Models.Item", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("NymaEshop2.Models.Product", b =>
                {
                    b.Navigation("CategoryToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
