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
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("Cars");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Engine>(entity =>
            {
                entity
                    .HasMany(engine => engine.Cars)
                    .WithOne(Cars => Cars.engine)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            Brand BMW = new Brand() { Id = 1, Name = "BMW", Country = "Germany" };
            Brand Opel = new Brand { Id = 2, Name = "Opel", Country = "France" };
            Brand Honda = new Brand { Id = 3, Name = "Honda", Country = "Japan" };
            Brand Mercedes = new Brand { Id = 4, Name = "Mercedes-Benz", Country = "Germany" };
            Brand Ford = new Brand { Id = 5, Name = "Ford", Country = "United States of Amrica" };

            Engine S63 = new Engine() { Id = 1, Name = "S63", Hp = 617, Torqe = 750, Cylinders = 8 };
            Engine EB2DTS = new Engine() { Id = 2, Name = " EB2ADTD/EB2DTS", Hp = 182, Torqe = 230, Cylinders = 4 };
            Engine K20C1 = new Engine() { Id = 3, Name = "K20C1 turbocharged I4", Hp = 316, Torqe = 350, Cylinders = 4 };
            Engine M177 = new Engine() { Id = 4, Name = "M177 DE40 LA", Hp = 604, Torqe = 850, Cylinders = 8 };
            Engine TDCi = new Engine() { Id = 5, Name = "Duratorq TDCi", Hp = 170, Torqe = 400, Cylinders = 4 };

            Car X6 = new Car() { Id = 1, Name = "X6", Year = 2022, Km = 8763, BrandId = BMW.Id, EngineId = S63.Id };
            Car Mokka = new Car() { Id = 2, Name = "Mokka", Year = 2020, Km = 27504, BrandId = Opel.Id, EngineId = EB2DTS.Id };
            Car Civic = new Car() { Id = 3, Name = "Civic Type R", Year = 2021, Km = 13400, BrandId = Honda.Id, EngineId = K20C1.Id };
            Car EClass = new Car() { Id = 4, Name = "E220d", Year = 2019, Km = 58640, BrandId = Mercedes.Id, EngineId = M177.Id };
            Car Transit = new Car() { Id = 5, Name = "Transit Custom Sport", Year = 2022, BrandId = Ford.Id, EngineId = TDCi.Id };

            modelBuilder.Entity<Brand>().HasData(BMW, Opel, Honda, Mercedes, Ford);
            modelBuilder.Entity<Engine>().HasData(S63, EB2DTS, K20C1, M177, TDCi);
            modelBuilder.Entity<Car>().HasData(X6, Mokka, Civic, EClass, Transit);
        }
    }
}
