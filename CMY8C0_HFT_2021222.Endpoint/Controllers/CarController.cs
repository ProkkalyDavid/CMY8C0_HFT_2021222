using CMY8C0_HFT_2021222.Endpoint.Services;
using CMY8C0_HFT_2021222.Logic;
using CMY8C0_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMY8C0_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic logic;
        IHubContext<SignalRHub> hub;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CarCreated", value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Update([FromBody] Car value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CarUpdated", value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carToDelete = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted", carToDelete);
        }
    }
}