using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using BiciEventos.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BiciEventos.Controllers
{
    [Route("api/[controller]")]
    public class InvitesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvitesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new ObjectResult(_unitOfWork.Invites.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int invitedId, int inviterId, int eventId)
        {
            var invite = _unitOfWork.Invites.GetInvite(invitedId, inviterId, eventId);
            if (invite == null)
                return NotFound();
            return new ObjectResult(invite);
        }

        [HttpPost]
        public void Post([FromBody]Invite invite)
        {
            _unitOfWork.Invites.Add(invite);
            _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Invite invite)
        {
            _unitOfWork.Invites.Edit(invite);
            _unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int invitedId, int inviterId, int eventId)
        {
            var toRemoveInvite = _unitOfWork.Invites.Delete(invitedId, inviterId, eventId);
            if (toRemoveInvite == null)
                return NotFound();
            _unitOfWork.Complete();
            return Ok(toRemoveInvite);
        }
    }
}
