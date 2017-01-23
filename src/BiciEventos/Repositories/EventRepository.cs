﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public class EventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Single(e => e.Id == id);
        }

        public void Add(Event evento)
        {
            _context.Events.Add(evento);
        }

        public Event Delete(int id)
        {
            if (_context.Events.Any(e => e.Id == id))
            {
                var evento = _context.Events.Single(e => e.Id == id);
                _context.Events.Remove(evento);
                return evento;
            }
            return null;
        }

        public void Edit(Event evento)
        {
            _context.Events.Update(evento);
        }
    }
}
