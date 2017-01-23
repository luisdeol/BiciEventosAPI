using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace BiciEventos.Models
{
    public class Attendance
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}