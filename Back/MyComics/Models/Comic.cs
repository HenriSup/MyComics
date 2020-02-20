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
        private string coverLink;
        private string thumbnailLink;
        private string content;
        private string writer;
        private int categoryId;
        private string synopsis;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string CoverLink { get => coverLink; set => coverLink = value; }
        public string ThumbnailLink { get => thumbnailLink; set => thumbnailLink = value; }
        public string Content { get => content; set => content = value; }
        public string Writer { get => writer; set => writer = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string Synopsis { get => synopsis; set => synopsis = value; }

        public Category Category { get ; set; }
    }
}

