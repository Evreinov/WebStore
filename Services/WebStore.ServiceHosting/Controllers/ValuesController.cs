﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.TestWebAPI)]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> __Values = Enumerable
            .Range(1, 10)
            .Select(i => $"Value={i:00}")
            .ToList();

        [HttpGet] // http://localhost:5001/api/values
        public IEnumerable<string> Get() => __Values;

        //[HttpGet] // http://localhost:5001/api/values
        //public ActionResult<IEnumerable<string>> Get() => __Values;
    
        [HttpGet("{id}")] // http://localhost:5001/api/values/5
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            return __Values[id];
        }

        [HttpPost]              // post -> http://localhost:5001/api/values
        [HttpPost("add")]       // post -> http://localhost:5001/api/values/add
        public ActionResult Post([FromBody]string value)
        {
            __Values.Add(value);
            // return Ok();
            return CreatedAtAction(nameof(Get), new { id = __Values.Count - 1 });
        }

        [HttpPut]              // put -> http://localhost:5001/api/values/5
        [HttpPut("edit/{id}")]       // put -> http://localhost:5001/api/values/edit/5
        public ActionResult Put(int id, [FromBody]string value)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            __Values[id] = value;
            return Ok();
        }

        [HttpDelete("{id}")] // delete -> http://localhost:5001/api/values/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            __Values.RemoveAt(id);
            return Ok();
        }
    }
}
