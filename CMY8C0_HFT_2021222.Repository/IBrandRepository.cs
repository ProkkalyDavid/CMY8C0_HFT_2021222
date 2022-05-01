using CMY8C0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
        void Delete(int id);
    }
}
