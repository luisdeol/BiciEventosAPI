using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiciEventos.Models;
using BiciEventos.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BiciEventos.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private UnitOfWork _unitOfWork;

        public EventsController(ApplicationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _unitOfWork.Events.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            var evento = _unitOfWork.Events.GetEvent(id);
            _unitOfWork.IsComplete();
            return evento;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event evento)
        {
            _unitOfWork.Events.Add(evento);
            _unitOfWork.IsComplete();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event evento)
        {
            _unitOfWork.Events.Edit(evento);
            _unitOfWork.IsComplete();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Events.Delete(id);
            _unitOfWork.IsComplete();
        }
    }
}
