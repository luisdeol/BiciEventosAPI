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

        public ActionResult Get(Invite inviteObj)
        {
            var invite = _unitOfWork.Invites.GetInvite(inviteObj.InvitedId, inviteObj.InviterId, inviteObj.EventId);
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

        [HttpPut]
        public void Put([FromBody]Invite invite)
        {
            _unitOfWork.Invites.Edit(invite);
            _unitOfWork.Complete();
        }

        [HttpDelete]
        public ActionResult Delete(Invite inviteObj)
        {
            var toRemoveInvite = _unitOfWork.Invites.Delete(inviteObj.InvitedId, inviteObj.InviterId, inviteObj.EventId);
            if (toRemoveInvite == null)
                return NotFound();
            _unitOfWork.Complete();
            return Ok(toRemoveInvite);
        }
    }
}
