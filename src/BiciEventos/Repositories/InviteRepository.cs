using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace BiciEventos.Repositories
{
    public class InviteRepository : IInviteRepository
    {
        private readonly ApplicationDbContext _context;

        public InviteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Invite> GetAll()
        {
            return _context.Invites.ToList();
        }

        public Invite GetInvite(int invitedId, int inviterId, int eventId)
        {
            return _context.Invites
                .SingleOrDefault(i => i.InvitedId == invitedId &&
                            i.InviterId == inviterId &&
                            i.EventId == eventId);
        }

        public void Add(Invite invite)
        {
            _context.Invites.Add(invite);
        }

        public void Edit(Invite invite)
        {
            _context.Invites.Update(invite);
        }

        public Invite Delete(int invitedId, int inviterId, int eventId)
        {
            var invite = GetInvite(invitedId, inviterId, eventId);
            if (invite != null)
                _context.Invites.Remove(invite);
            return invite;
        }
    }
}
