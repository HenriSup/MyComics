using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyComics.Models;
namespace MyComics.Controllers
{
    [EnableCors("allowsAll")]
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Customer.ToList());
        }

        [HttpGet("{nickname}")]
        public IActionResult GetByNickname(string nickname , string pass)
        {
            DataContext db = new DataContext();
            Customer customer = db.Customer.FirstOrDefault(c => c.Nickname.ToLower() == nickname.ToLower());
            if(customer != null)
            {
                return Ok(customer);
                           
            }
            else
            {
                return NotFound();
            }
            
            
        }


        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            DataContext db = new DataContext();
            db.Customer.Add(customer);
            db.SaveChanges();
            return Ok(new { id = customer.Id , message = "Customer added" });
        }

        //[HttpPut("{update}")]
        //public IActionResult Put(string nickname, [FromBody]Customer customer)
        //{
        //    DataContext db = new DataContext();
        //    Customer c = db.Customer.FirstOrDefault(x => x.Nickname == nickname);
        //    if (c != null)
        //    {
        //        c.Nickname = customer.Nickname;
        //        c.Pass = customer.Pass;
        //        db.SaveChanges();
        //        return Ok(new { message = "update Ok" });
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpDelete("{nickname}")]
        public IActionResult Delete(string nickname)
        {
            DataContext db = new DataContext();
            Customer c = db.Customer.FirstOrDefault(x => x.Nickname == nickname);
            if (c != null)
            {
                db.Customer.Remove(c);
                db.SaveChanges();
                return Ok(new { message = "Delete ok" });
            }
            else
            {
                return NotFound();
            }
        }


    }
}