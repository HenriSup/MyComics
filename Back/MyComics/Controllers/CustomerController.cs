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

        [HttpGet("search/{login}")]
        public IActionResult Get(string login)
        {
            DataContext db = new DataContext();
            List<Customer> customers = db.Customer.Where(c => c.Login.Contains(login)).ToList();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            DataContext db = new DataContext();
            db.Customer.Add(customer);
            db.SaveChanges();
            return Ok(new { message = "Customer added" });
        }

        [HttpPut("{login}")]
        public IActionResult Put(string login, [FromBody]Customer customer)
        {
            DataContext db = new DataContext();
            Customer c = db.Customer.Include(x => x.ListCustomerComic).FirstOrDefault(x => x.Login == login);
            if (c != null)
            {
                c.Firstname = customer.Firstname;
                c.Lastname = customer.Lastname;
                c.Pwd = customer.Pwd;
                if (customer.ListCustomerComic.Count > 0)
                {
                    c.ListCustomerComic.Clear();
                    c.ListCustomerComic = customer.ListCustomerComic;
                }
                db.SaveChanges();
                return Ok(new { message = "update Ok" });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{login}")]
        public IActionResult Delete(string login)
        {
            DataContext db = new DataContext();
            Customer c = db.Customer.Include(x => x.ListCustomerComic).FirstOrDefault(x => x.Login == login);
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