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
        private string firstname;
        private string lastname;
        private string login;
        private string pwd;
        private List<CustomerComic> listCustomerComic;

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public List<CustomerComic> ListCustomerComic { get => listCustomerComic; set => listCustomerComic = value; }

        [Column("log_in")]
        public string Login { get => login; set => login = value; }
        
    }
}
