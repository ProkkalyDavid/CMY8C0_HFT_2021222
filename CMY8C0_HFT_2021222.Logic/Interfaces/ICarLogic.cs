using CMY8C0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMY8C0_HFT_2021222.Logic
{
    public interface ICarLogic
    {
        IEnumerable<CarsaByBrands> CarsByBrands();
        IEnumerable<Car> CarsWithV8();
        void Create(Car item);
        void Delete(int id);
        IEnumerable<Car> GermanPremium();
        IEnumerable<HighestMileage> HighestMileage();
        IEnumerable<Oldest> OldestCar();
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
    }
}