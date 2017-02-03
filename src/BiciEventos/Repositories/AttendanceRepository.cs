using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Attendance> GetAll()
        {
            return _context.Attendances.ToList();
        }

        public Attendance GetAttendance(int userId, int eventId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.UserId == userId && a.EventId == eventId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Edit(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
        }
        public Attendance Delete(int userId, int eventId)
        {
            var attendance = GetAttendance(userId, eventId);
            if (attendance != null)
                _context.Attendances.Remove(attendance);
            return attendance;
        }
    }
}
