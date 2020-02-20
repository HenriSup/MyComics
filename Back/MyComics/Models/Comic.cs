using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComics.Models
{
    public class Comic
    {
        private int id;
        private string title;
        private string cover;
        private string content;
        private string author;
        private Category category;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Cover { get => cover; set => cover = value; }
        public string Author { get => author; set => author = value; }
        public Category Category { get => category; set => category = value; }
        public string Content { get => content; set => content = value; }
    }

    public enum Category
    {
        Comics,
        Manga,
        BDFrancoBelge
    }
}

