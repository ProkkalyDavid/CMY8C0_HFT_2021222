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
        public IEnumerable<Oldest> OldesCar()
        {
            return this.carLogic.OldestCar();
        }

        // GET api/<StatController>/5
        [HttpGet]
        public IEnumerable<Car> CarsWithV8()
        {
            return this.carLogic.CarsWithV8();
        }

        [HttpGet]
        public IEnumerable<HighestMileage> HighestMileage()
        {
            return this.carLogic.HighestMileage();
        }

        [HttpGet]
        public IEnumerable<Car> GermanPremium()
        {
            return this.carLogic.GermanPremium();
        }

        [HttpGet]
        public IEnumerable<CarsaByBrands> CarsByBrands()
        {
            return this.carLogic.CarsByBrands();
        }

        [HttpGet]
        public IEnumerable<MostHp> MostHps()
        {
            return this.engineLogic.MostHps();
        }

        [HttpGet]
        public IEnumerable<BrandsByCountries> BrandsByCountries()
        {
            return this.brandLogic.BrandsByCountries();
        }
    }
}
