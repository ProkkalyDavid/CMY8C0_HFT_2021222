using CMY8C0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMY8C0_HFT_2021222.Logic
{
    public interface IBrandLogic
    {
        IEnumerable<BrandsByCountries> BrandsByCountries();
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
    }
}