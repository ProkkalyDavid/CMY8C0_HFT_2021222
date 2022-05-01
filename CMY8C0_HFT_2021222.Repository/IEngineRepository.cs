using CMY8C0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Repository
{
    internal interface IEngineRepository
    {
        void Create(Engine engine);
        Engine Read(int id);
        IQueryable<Engine> ReadAll();
        void Update(Engine engine);
        void Delete(int id);
    }
}
