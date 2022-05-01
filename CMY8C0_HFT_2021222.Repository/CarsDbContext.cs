using CMY8C0_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Repository
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }

        public CarsDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Cars.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engine>(entity =>
            {
                entity
                    .HasMany(engine => engine.Cars)
                    .WithOne(Cars => Cars.engine)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity
                    .HasMany(brand => brand.Cars)
                    .WithOne(car => car.brand)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity
                    .HasOne(car => car.engine)
                    .WithMany(engine => engine.Cars)
                    .HasForeignKey(Cars => Cars.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity
                    .HasOne(car => car.brand)
                    .WithMany(brand => brand.Cars)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
