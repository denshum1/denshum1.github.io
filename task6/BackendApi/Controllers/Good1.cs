using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Good1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public Good1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Good> good = Context.Goods.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int prodId, int delivId)
        {
            Good? good = Context.Goods.Where(x => x.GProdId == prodId & x.GDelivId == delivId).FirstOrDefault();
            if (good == null)
                return BadRequest("lol");
            return Ok(good);
        }
        [HttpPost]
        public IActionResult Add(Good good)
        {
            Context.Goods.Add(good);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Good good)
        {
            Context.Goods.Update(good);
            Context.SaveChanges();
            return Ok(good);
        }
        [HttpDelete]
        public IActionResult Delete(int delivId, int prodId)
        {
            Good? good = Context.Goods.Where(x => x.GDelivId == delivId & x.GProdId == prodId).FirstOrDefault();
            if (good == null)
                return BadRequest("Nah");
            Context.Goods.Remove(good);
            Context.SaveChanges();
            return Ok();
        }
    }



}