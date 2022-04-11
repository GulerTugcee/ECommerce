using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entities.Concrete;//-----
using Microsoft.EntityFrameworkCore;


namespace ECommerce.DataAccess.Concrete
{
    public class EcommerceContext : DbContext // EcommerceContext DATABASE NESNESİ DbContext den kalıtım almak zorundadır
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=185.242.162.113;Initial Catalog=db1_otel;User ID=db1_otel;Password=Abc123@@");
        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }//Tablonun modeli ve gerçek adı // bu prop adı kesinlikle tablo adı ile aynı olmak zorundaduır.
        public DbSet<UserToken> UserTokens { get; set; }//kullanıcının tokenlerini tutacak
        public DbSet<Product> Products { get; set; }//Ürünleri tutacak

        public DbSet<Category> Categories { get; set; } // kategoriler
        public DbSet<ProductImage> ProductImages { get; set; } 
        public DbSet<CategoryProduct> CategoryProducts { get; set; } 
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}