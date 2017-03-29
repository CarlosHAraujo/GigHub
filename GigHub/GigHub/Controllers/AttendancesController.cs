using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private Context _context;

        public AttendancesController()
        {
            _context = new Context();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto gigId)
        {
            string userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId.GigId))
            {
                return BadRequest("The attendance already exists.");
            }
            var attendance = new Attendance
            {
                GigId = gigId.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
