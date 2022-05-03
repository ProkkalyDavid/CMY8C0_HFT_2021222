using System;
using System.Linq;
using CMY8C0_HFT_2021222.Models;
using CMY8C0_HFT_2021222.Repository;
using CMY8C0_HFT_2021222.Logic;


namespace CMY8C0_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test
            var ctx = new CarsDbContext();
            var repo = new CarRepository(ctx);
            var logic = new CarLogic(repo);

            logic.Create(new Car()
            {
                BrandId = 1,
                EngineId = 1,
                Km = 4000,
                Id = 6,
                Name = "M5 Competiton",
                Year = 2021
            });
            var all = logic.ReadAll().ToArray();
            var mileage = logic.HighestMileage().ToArray();
            var cars = logic.CarsByBrands().ToArray();
            var V8 = logic.CasWithV8().ToArray();
            var germans = logic.GermanPremium().ToArray();
            var oldest = logic.OldestCar().ToArray();

            ;
        }
    }
}
