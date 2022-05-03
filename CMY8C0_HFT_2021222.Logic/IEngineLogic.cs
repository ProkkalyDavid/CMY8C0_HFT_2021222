using CMY8C0_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMY8C0_HFT_2021222.Logic
{
    public interface IEngineLogic
    {
        void Create(Engine item);
        void Delete(int id);
        IEnumerable<MostHp> MostHps();
        Engine Read(int id);
        IQueryable<Engine> ReadAll();
        void Update(Engine item);
    }
}