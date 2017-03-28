using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController()
        {
            _context = new Context();
        }

        public ActionResult Index()
        {
            var upgoingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Where(g => g.DateTime > DateTime.Now)
                .ToList();
            return View(upgoingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}