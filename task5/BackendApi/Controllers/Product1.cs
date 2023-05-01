using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public Product1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> cat = Context.Products.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product? cat = Context.Products.Where(x => x.PId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("lol");
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult Add(Product cat)
        {
            Context.Products.Add(cat);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Product cat)
        {
            Context.Products.Update(cat);
            Context.SaveChanges();
            return Ok(cat);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product? cat = Context.Products.Where(x => x.PId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("Nah");
            Context.Products.Remove(cat);
            Context.SaveChanges();
            return Ok();
        }
    }



}