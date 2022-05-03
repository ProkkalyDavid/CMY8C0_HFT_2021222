using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMY8C0_HFT_2021222.Repository;
using CMY8C0_HFT_2021222.Models;

namespace CMY8C0_HFT_2021222.Logic
{
    public class EngineLogic : IEngineLogic
    {
        IRepository<Engine> repository;

        public EngineLogic(IRepository<Engine> repository)
        {
            this.repository = repository;
        }

        public void Create(Engine item)
        {
            if (item.Hp <= 0)
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

        public Engine Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Engine> ReadAll()
        {
            return this.ReadAll();
        }

        public void Update(Engine item)
        {
            if (item.Hp < 1 || item.Name == null)
            {
                throw new Exception();
            }
            else
            {
                this.repository.Update(item);
            }
        }

        public IEnumerable<MostHp> MostHps()
        {
            return (from x in repository.ReadAll()
                    orderby x.Hp descending
                    select new MostHp
                    {
                        Hp = x.Hp,
                        EngineName = x.Name
                    }).Take(1);
        }
    }
    public class MostHp
    {
        public string EngineName { get; set; }
        public int Hp { get; set; }
    }
}
