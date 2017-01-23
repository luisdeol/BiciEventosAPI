using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using BiciEventos.Repositories;

namespace BiciEventos.Persistence
{
    public class UnitOfWork
    {
        public EventRepository Events;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
        }

        public void IsComplete()
        {
            _context.SaveChanges();
        }
    }
}
