using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public Category1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> cat = Context.Categories.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category? cat = Context.Categories.Where(x => x.CId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("lol");
            return Ok(cat);
        }
        [HttpPost]
        public IActionResult Add(Category cat)
        {
            Context.Categories.Add(cat);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Category cat)
        {
            Context.Categories.Update(cat);
            Context.SaveChanges();
            return Ok(cat);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category? cat = Context.Categories.Where(x => x.CId == id).FirstOrDefault();
            if (cat == null)
                return BadRequest("Nah");
            Context.Categories.Remove(cat);
            Context.SaveChanges();
            return Ok();
        }
    }



}