using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Server.Kestrel.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BiciEventos.Models
{
    public class Invite
    {
        public int EventId { get; set; }
        public int InvitedId { get; set; }
        public int InviterId { get; set; }

        public Event Event { get; set; }
        public User Inviter { get; set; }
        public User Invited { get; set; }
    }
}