using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Delivery1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public Delivery1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Delivery> cat = Context.Deliveries.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Delivery? cat = Context.Deliveries.Where(x => x.DId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("lol");
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult Add(Delivery cat)
        {
            Context.Deliveries.Add(cat);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Delivery cat)
        {
            Context.Deliveries.Update(cat);
            Context.SaveChanges();
            return Ok(cat);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Delivery? cat = Context.Deliveries.Where(x => x.DId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("Nah");
            Context.Deliveries.Remove(cat);
            Context.SaveChanges();
            return Ok();
        }
    }



}