using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using BiciEventos.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BiciEventos.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new ObjectResult(_unitOfWork.Users.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _unitOfWork.Users.GetUser(id);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpPost]
        public void Post([FromBody] UserRequest user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put([FromBody]User user)
        {
            _unitOfWork.Users.Edit(user);
            _unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var removedUser = _unitOfWork.Users.Delete(id);
            if (removedUser == null)
                return NotFound();
            _unitOfWork.Complete();
            return Ok(removedUser);
        }
    }
}
