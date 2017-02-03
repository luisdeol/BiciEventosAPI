using System.Collections.Generic;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public interface IEventRepository
    {
        List<Event> GetAll();
        Event GetEvent(int id);
        void Add(Event evento);
        Event Delete(int id);
        void Edit(Event evento);
    }
}