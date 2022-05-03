using CMY8C0_HFT_2021222.Models;
using CMY8C0_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repository;
        public void Create(Brand item)
        {
            if (item.Name == null)
            {
                throw new ArgumentException("must enter a name");
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

        public Brand Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Brand item)
        {
            this.repository.Update(item);
        }

        public IEnumerable<BrandsByCountries> BrandsByCountries()
        {
            return (from x in repository.ReadAll()
                    group x by x.Country into g
                    select new BrandsByCountries
                    {
                        Country = g.Key,
                        BrandCount = repository.ReadAll().Where(t => t.Country == g.Key).Count()
                    });
        }
    }
    public class BrandsByCountries
    {
        public string Country { get; set; }
        public int BrandCount { get; set; }
    }
}
