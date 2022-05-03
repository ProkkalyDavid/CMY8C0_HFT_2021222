using CMY8C0_HFT_2021222.Logic;
using CMY8C0_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMY8C0_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        IEngineLogic logic;

        public EngineController(IEngineLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<EngineController>/5
        [HttpPut]
        public void Update([FromBody] Engine value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<EngineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
