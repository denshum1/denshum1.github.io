using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public User1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> user = Context.Users.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.UId == id).FirstOrDefault();
            if (user == null)
                return BadRequest("lol");
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add (User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
           Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.UId == id).FirstOrDefault();
            if (user == null)
                return BadRequest("Nah");
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
   


}