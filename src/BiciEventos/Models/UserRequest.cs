using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiciEventos.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
