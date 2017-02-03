using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using BiciEventos.Repositories;

namespace BiciEventos.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository Events { get; }
        public IUserRepository Users { get; }
        public IAttendanceRepository Attendances { get; }
        public IInviteRepository Invites { get; }
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
            Users = new UserRepository(_context);
            Attendances = new AttendanceRepository(_context);
            Invites = new InviteRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
