using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCart1 : ControllerBase
    {
        public Int_shopContext Context { get; }
        public ShopCart1(Int_shopContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ShopCart> good = Context.ShopCarts.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int prodId, int userId)
        {
            ShopCart? good = Context.ShopCarts.Where(x => x.SProductId == prodId & x.SUserId == userId).FirstOrDefault();
            if (good == null)
                return BadRequest("lol");
            return Ok(good);
        }
        [HttpPost]
        public IActionResult Add(ShopCart good)
        {
            Context.ShopCarts.Add(good);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ShopCart good)
        {
            Context.ShopCarts.Update(good);
            Context.SaveChanges();
            return Ok(good);
        }
        [HttpDelete]
        public IActionResult Delete(int userId, int prodId)
        {
            ShopCart? good = Context.ShopCarts.Where(x => x.SUserId == userId & x.SProductId == prodId).FirstOrDefault();
            if (good == null)
                return BadRequest("Nah");
            Context.ShopCarts.Remove(good);
            Context.SaveChanges();
            return Ok();
        }
    }



}