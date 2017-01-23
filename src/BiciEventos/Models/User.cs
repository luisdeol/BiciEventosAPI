using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciEventos.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<Event> Events { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Invite> InvitesSent { get; set; }
        public List<Invite> InvitesReceived { get; set; }

        public User()
        {
            
        }
        public User(string userName, string password)
        {
            Username = userName;
            Password = password;
            RegisterDate = DateTime.Now;
        }
    }
}