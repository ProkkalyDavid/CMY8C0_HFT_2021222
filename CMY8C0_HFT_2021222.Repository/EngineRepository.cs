using CMY8C0_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.Repository
{
    public class EngineRepository : Repository<Engine>, IRepository<Engine>
    {
        public EngineRepository(CarsDbContext ctx) : base(ctx)
        {
        }

        public override Engine Read(int id)
        {
            return ctx.Engines.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Engine item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
