using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace BiciEventos.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Event> GetAll()
        {
            return _context.Events.Include(e => e.User);
        }

        public Event GetEvent(int id)
        {
            return _context.Events.SingleOrDefault(e => e.Id == id);
        }

        public void Add(Event evento)
        {
            _context.Events.Add(evento);
        }

        public Event Delete(int id)
        {
            var evento = GetEvent(id);
            if (evento != null)
                _context.Events.Remove(evento);
            return evento;
        }

        public void Edit(Event evento)
        {
            _context.Events.Update(evento);
        }
    }
}
