using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComics.Models
{
    public class Favorite
    {
        private int id;
        private int customerId;
        private int comicId;

        public int Id { get => id; set => id = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int ComicId { get => comicId; set => comicId = value; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        
    }
}
