using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComics.Models
{
    public class CustomerComic
    {
        private int customer_id;
        private int comic_id;
       
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Comic_id { get => comic_id; set => comic_id = value; }

        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
