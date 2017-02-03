using BiciEventos.Repositories;

namespace BiciEventos.Persistence
{
    public interface IUnitOfWork
    {
        IEventRepository Events { get; }
        IUserRepository Users { get; }
        IAttendanceRepository Attendances { get; }
        IInviteRepository Invites { get; }
        void Complete();
    }
}