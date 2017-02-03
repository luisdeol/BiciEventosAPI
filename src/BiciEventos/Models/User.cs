using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace BiciEventos.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        /*public string PasswordHash { get; private set; }

        public byte[] Salt { get; private set; }*/

        public DateTime RegisterDate { get; set; }
        public List<Event> Events { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Invite> InvitesSent { get; set; }
        public List<Invite> InvitesReceived { get; set; }

        public User()
        {
            
        }
        public User(string userName, string password, DateTime registerDate)
        {
            Username = userName;
            Password = password;
            RegisterDate = registerDate;
        }

        /*private string GetPasswordHash(string password)
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            this.Salt = salt;

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = pbkdf2.GetBytes(20);

            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            var savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }*/
    }
}