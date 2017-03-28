using GigHub.Models;
using GigHub.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private Context _context { get; set; }

        public GigsController()
        {
            _context = new Context();
        }

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel();
            viewModel.Genres = _context.Genres.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(GigFormViewModel model)
        {
            var gig = new Gig
            {
                ArtistId = 1,
                DateTime = DateTime.Parse(String.Format("{0} {1}", model.Date, model.Time)),
                GenreId = model.Genre,
                Venue = model.Venue
            };
            return RedirectToAction("Index", "Home");
        }
    }
}