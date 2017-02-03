using System.Collections.Generic;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAll();
        Attendance GetAttendance(int userId, int eventId);
        void Add(Attendance attendance);
        Attendance Delete(int userId, int eventId);
        void Edit(Attendance attendance);
    }
}