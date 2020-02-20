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
            return Ok(db.Comic.Include(x => x.Category).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DataContext db = new DataContext();
            Comic c = db.Comic.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return Ok(c);
        }

        [HttpGet("title/{title}")]
        public IActionResult GetComicByTitle(string title)
        {
            DataContext db = new DataContext();
            List<Comic> comics = db.Comic.Include(x => x.Category).Where(c => c.Title.Contains(title)).ToList();
            return Ok(comics);
        }

        [HttpGet("writer/{writer}")]
        public IActionResult GetComicsByWriter(string writer)
        {
            DataContext db = new DataContext();
            List<Comic> comics = db.Comic.Include(x => x.Category).Where(c => c.Writer.Contains(writer)).ToList();
            return Ok(comics);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetComicByCategory(int categoryId)
        {
            DataContext db = new DataContext();
            List<Comic> comics = db.Comic.Include(x => x.Category).Where(c => c.Category.Id == categoryId).ToList();
            return Ok(comics);
        }

        //TODO v

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