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
    public class ComicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Comic.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DataContext db = new DataContext();
            Comic c = db.Comic.FirstOrDefault(x => x.Id == id);
            return Ok(c);
        }

        [HttpGet("title/{title}")]
        public IActionResult Get(string title)
        {
            DataContext db = new DataContext();
            List<Comic> comics = db.Comic.Where(c => c.Title.Contains(title)).ToList();
            return Ok(comics);
        }

        [HttpGet("author/{author}")]
        public IActionResult Get2(string author)
        {
            DataContext db = new DataContext();
            List<Comic> authors = db.Comic.Where(c => c.Author.Contains(author)).ToList();
            return Ok(authors);
        }

        [HttpGet("category/{category}")]
        public IActionResult Get2(int category)
        {
            DataContext db = new DataContext();
            List<Comic> cat = db.Comic.Where(c => c.Category == (Category)category ).ToList();
            return Ok(cat);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Comic comic)
        {
            DataContext db = new DataContext();
            db.Comic.Add(comic);
            db.SaveChanges();
            return Ok(new { comic.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataContext db = new DataContext();
            Comic comicToDelete = db.Comic.FirstOrDefault(x => x.Id == id);
            if(comicToDelete != null)
            {
                db.Comic.Remove(comicToDelete);
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