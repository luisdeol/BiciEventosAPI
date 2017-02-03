using System.Collections.Generic;
using BiciEventos.Models;

namespace BiciEventos.Repositories
{
    public interface IInviteRepository
    {
        List<Invite> GetAll();
        Invite GetInvite(int invitedId, int inviterId, int eventId);
        void Add(Invite invite);
        void Edit(Invite invite);
        Invite Delete(int invitedId, int inviterId, int eventId);
    }
}