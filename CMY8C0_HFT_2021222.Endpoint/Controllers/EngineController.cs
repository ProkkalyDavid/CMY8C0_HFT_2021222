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
    public class EngineController : ControllerBase
    {
        IEngineLogic logic;
        IHubContext<SignalRHub> hub;

        public EngineController(IEngineLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // GET: api/<EngineController>
        [HttpGet]
        public IEnumerable<Engine> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<EngineController>/5
        [HttpGet("{id}")]
        public Engine Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<EngineController>
        [HttpPost]
        public void Create([FromBody] Engine value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("EngineCreated", value);
        }

        // PUT api/<EngineController>/5
        [HttpPut]
        public void Update([FromBody] Engine value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("EngineUpdated", value);
        }

        // DELETE api/<EngineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var engineToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("EngineDeleted", engineToDelete);
        }
    }
}
