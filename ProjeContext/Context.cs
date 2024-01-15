using System;
using Microsoft.EntityFrameworkCore;
using Proje_OOP.Entity;

namespace Proje_OOP.ProjeContext
{
	public class Context : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=OOPCore;uid=root; password=123456aA; Charset=utf8mb4",
                ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=OOPCore;uid=root; password=123456aA; Charset=utf8mb4"));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}

