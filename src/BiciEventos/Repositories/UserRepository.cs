using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int userId)
        {
            return _context.Users.SingleOrDefault(e => e.Id == userId);
        }

        public void Add(UserRequest user)
        {
            var newUser = new User(user.Username, user.Password, user.RegisterDate);
            _context.Users.Add(newUser);
        }

        public User Delete(int userId)
        {
            var user = GetUser(userId);
            if (user != null)
                _context.Users.Remove(user);
            return user;
        }

        public void Edit(User user)
        {
            _context.Users.Update(user);
        }
    }
}
