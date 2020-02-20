using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComics.Models
{
    public class Customer
    {
        private int id;
        private string nickname;
        private string pass;
        private bool isAdmin;

        public int Id { get => id; set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
