using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyComics.Models
{
    public class Category
    {
        private int id;
        private string title;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

        [JsonIgnore]
        public List<Comic> Comics;

        public Category()
        {
            Comics = new List<Comic>();
        }
    }
}