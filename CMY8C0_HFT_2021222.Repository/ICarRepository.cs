using CMY8C0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Repository
{
    internal interface ICarRepository
    {
        void Create(Car car);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car car);
        void Delete(int id);
    }
}
