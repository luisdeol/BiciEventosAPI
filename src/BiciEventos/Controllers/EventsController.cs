using System.Collections.Generic;
using System.Linq;
using BiciEventos.Models;
using BiciEventos.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BiciEventos.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IQueryable<Event> GetAll()
        {
            return _unitOfWork.Events.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var evento = _unitOfWork.Events.GetEvent(id);
            if (evento == null)
                return NotFound();
            return new ObjectResult(evento);
        }

        [HttpPost]
        public void Post([FromBody]Event evento)
        {
            _unitOfWork.Events.Add(evento);
            _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Event evento)
        {
            _unitOfWork.Events.Edit(evento);
            _unitOfWork.Complete();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var removedEvent= _unitOfWork.Events.Delete(id);
            if (removedEvent == null)
                return NotFound();
            _unitOfWork.Complete();
            return Ok(removedEvent);
        }
    }
}
