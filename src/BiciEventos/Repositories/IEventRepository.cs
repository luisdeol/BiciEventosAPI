using System.Collections.Generic;
using System.Linq;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAll();
        Event GetEvent(int id);
        void Add(Event evento);
        Event Delete(int id);
        void Edit(Event evento);
    }
}