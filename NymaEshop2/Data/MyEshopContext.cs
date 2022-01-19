using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NymaEshop2.Models;

namespace NymaEshop2.Data
{
    public class MyEshopContext:DbContext
    {

        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> users { get; set; }

        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region key

            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.Categoryid, t.Productid });

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.PriceIT).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });




            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    PriceIT = 854.0M,
                    QuantityInStock = 5
                },
            new Item()
            {
                Id = 2,
                PriceIT = 3302.0M,
                QuantityInStock = 8
            },
            new Item()
            {
                Id = 3,
                PriceIT = 2500,
                QuantityInStock = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemID = 1,
                NamePD = "آموزش Asp.Net Core 3 پروژه محور",
                DescriptionPD =
                        "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید."
            },
                new Product()
                {
                    Id = 2,
                    ItemID = 2,
                    NamePD = "آموزش Blazor از مقدماتی تا پیشرفته",
                    DescriptionPD =
                        "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است."
                },
                new Product()
                {
                    Id = 3,
                    ItemID = 3,
                    NamePD = "آموزش اپلیکیشن های وب پیش رونده ( PWA )",
                    DescriptionPD = "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند."
                });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { Categoryid = 1, Productid = 1 },
                new CategoryToProduct() { Categoryid = 2, Productid = 1 },
                new CategoryToProduct() { Categoryid = 3, Productid = 1 },
                new CategoryToProduct() { Categoryid = 4, Productid = 1 },
                new CategoryToProduct() { Categoryid = 1, Productid = 2 },
                new CategoryToProduct() { Categoryid = 2, Productid = 2 },
                new CategoryToProduct() { Categoryid = 3, Productid = 2 },
                new CategoryToProduct() { Categoryid = 4, Productid = 2 },
                new CategoryToProduct() { Categoryid = 1, Productid = 3 },
                new CategoryToProduct() { Categoryid = 2, Productid = 3 },
                new CategoryToProduct() { Categoryid = 3, Productid = 3 },
                new CategoryToProduct() { Categoryid = 4, Productid = 3 }
                );

            #endregion


            #region Seed Data Category

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                NameCT = "Asp.Net Core",
                DesvriptionCT = "Asp.Net Core 3"
            },
                new Category()
                {
                    Id = 2,
                    NameCT = "لباس ورزشی",
                    DesvriptionCT = "گروه لباس ورزشی"
                },
                new Category()
                {
                    Id = 3,
                    NameCT = "ساعت مچی",
                    DesvriptionCT = "گروه ساعت مچی"
                },
                new Category()
                {
                    Id = 4,
                    NameCT = "لوازم منزل",
                    DesvriptionCT = "گروه لوازم منزل"
                }
            );

            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
