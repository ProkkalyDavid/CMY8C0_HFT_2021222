using CMY8C0_HFT_2021222.Logic;
using CMY8C0_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMY8C0_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic carLogic;
        IBrandLogic brandLogic;
        IEngineLogic engineLogic;

        public StatController(ICarLogic carLogic, IBrandLogic brandLogic, IEngineLogic engineLogic)
        {
            this.carLogic = carLogic;
            this.brandLogic = brandLogic;
            this.engineLogic = engineLogic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<MostHp> MostHp()
        {
            return engineLogic.MostHps();
        }

        // GET api/<StatController>/5
        [HttpGet]
        public IEnumerable<BrandsByCountries> BrandsByCountries()
        {
            return brandLogic.BrandsByCountries();
        }

        [HttpGet]
        public IEnumerable<Car> CasWithV8()
        {
            return carLogic.CasWithV8();
        }

        [HttpGet]
        public IEnumerable<HighestMileage> HighestMileage()
        {
            return carLogic.HighestMileage();
        }

        [HttpGet]
        public IEnumerable<Car> GermanPremium()
        {
            return carLogic.GermanPremium();
        }

        [HttpGet]
        public IEnumerable<CarsaByBrands> CarsByBrands()
        {
            return carLogic.CarsByBrands();
        }

        [HttpGet]
        public IEnumerable<Oldest> OlderstCar()
        {
            return carLogic.OldestCar();
        }

        // POST api/<StatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
