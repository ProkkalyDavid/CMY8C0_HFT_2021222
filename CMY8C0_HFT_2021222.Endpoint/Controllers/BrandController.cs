﻿using CMY8C0_HFT_2021222.Endpoint.Services;
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
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);
        }
    }
}
