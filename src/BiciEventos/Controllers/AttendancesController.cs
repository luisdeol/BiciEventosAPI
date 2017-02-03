using BiciEventos.Models;
using BiciEventos.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BiciEventos.Controllers
{
    [Route("api/[controller]")]
    public class AttendancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new ObjectResult(_unitOfWork.Attendances.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int userId, int eventId)
        {
            var attendance = _unitOfWork.Attendances.GetAttendance(userId, eventId);
            if (attendance == null)
                return BadRequest();
            return new ObjectResult(attendance);
        }

        [HttpPost]
        public void Post([FromBody]Attendance attendance)
        {
            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Attendance attendance)
        {
            _unitOfWork.Attendances.Edit(attendance);
            _unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int userId, int eventId)
        {
            _unitOfWork.Attendances.Delete(userId, eventId);
            _unitOfWork.Complete();
        }
    }
}
