using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    { 
        private ApplicationDbContext _context;

        #region Constructor

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {

            MovieModel model = new MovieModel();
            model.Movies = _context.Movies.ToList();

            return View(model);
        }

        public ActionResult Details(int movieId)
        {
            var result = _context.Movies.FirstOrDefault(x => x.Id == movieId);

            return View(result);
        }
    }
}