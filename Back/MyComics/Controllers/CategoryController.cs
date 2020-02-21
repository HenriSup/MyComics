using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyComics.Models;

namespace MyComics.Controllers
{
    [EnableCors("allowsAll")]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Category.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DataContext db = new DataContext();
            Category c = db.Category.FirstOrDefault(x => x.Id == id);
            return Ok(c);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            DataContext db = new DataContext();
            db.Category.Add(category);
            db.SaveChanges();
            return Ok(new { category.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataContext db = new DataContext();
            Category categoryToDelete = db.Category.FirstOrDefault(x => x.Id == id);
            List<Comic> comicIntoCategoryDeleted = db.Comic.Where(x => x.CategoryId == categoryToDelete.Id).ToList();
            if (categoryToDelete != null)
            {
                foreach(Comic c in comicIntoCategoryDeleted)
                {
                    db.Comic.Remove(c);
                }
                db.Category.Remove(categoryToDelete);
                db.SaveChanges();
                return Ok(new { message = "deleted" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}