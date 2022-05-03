using System;
using System.Collections.Generic;
using System.Linq;
using CMY8C0_HFT_2021222.Models;
using CMY8C0_HFT_2021222.Repository;

namespace CMY8C0_HFT_2021222.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repository;

        public CarLogic(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public void Create(Car item)
        {
            if (item.Km < 0 || item.Name == null)
            {
                throw new Exception();
            }
            else
            {
                this.repository.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Car Read(int id)
        {
            if (this.repository.Read(id) == null)
            {
                throw new ArgumentException("wrong id");
            }
            else
            {
                return this.repository.Read(id);
            }
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Car item)
        {
            if (item.Km < 0)
            {
                throw new Exception();
            }
            else
            {
                this.repository.Update(item);
            }
        }

        public IEnumerable<Car> CasWithV8()
        {
            return repository.ReadAll().Where(t => t.engine.Cylinders == 8);
        }

        public IEnumerable<HighestMileage> HighestMileage()
        {
            return (from x in repository.ReadAll()
                    orderby x.Km descending
                    select new HighestMileage
                    {
                        Km = x.Km,
                        BrandName = x.brand.Name,
                        CarName = x.Name
                    }).Take(1);
        }

        public IEnumerable<Car> GermanPremium()
        {
            return repository.ReadAll().Where(t => t.brand.Country == "Germany");
        }

        public IEnumerable<CarsaByBrands> CarsByBrands()
        {
            return (from x in repository.ReadAll()
                    group x by x.brand.Name into g
                    select new CarsaByBrands
                    {
                        BrandName = g.Key,
                        CarCount = repository.ReadAll().Where(t => t.brand.Name == g.Key).Count()
                    });
        }

        public IEnumerable<Oldest> OldestCar()
        {
            return (from x in repository.ReadAll()
                    orderby x.Year ascending
                    select new Oldest
                    {
                        BrandName = x.brand.Name,
                        CarName = x.Name,
                        EngineName = x.engine.Name
                    }).Take(1);
        }
    }
    public class HighestMileage
    {
        public int Km { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
    }
    public class CarsaByBrands
    {
        public int CarCount;
        public string BrandName;
    }
    public class Oldest
    {
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string EngineName { get; set; }
    }
}
