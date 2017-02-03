using System.Collections.Generic;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUser(int id);
        void Add(UserRequest user);
        User Delete(int id);
        void Edit(User user);
    }
}