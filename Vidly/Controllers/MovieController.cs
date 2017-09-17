using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        #region Details

        public ActionResult Details(int movieId)
        {
            var result = _context.Movies.FirstOrDefault(x => x.Id == movieId);

            return View(result);
        }

        #endregion

        #region New - GET

        public ActionResult New()
        {

            List<string> genres = new List<string>()
            {
                "Action",
                "Comedy",
                "Romance",
                "Mistery"
            };

            ViewBag.Genres = genres;
            return View();
        }

        #endregion

        #region New - POST

        [HttpPost]
        public ActionResult New(Movie movie)
        {
            try
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
                return View("Index");
            }
        }

        #endregion

        #region Edit - GET

        public ActionResult Edit(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            List<string> genres = new List<string>()
            {
                "Action",
                "Comedy",
                "Romance",
                "Mistery"
            };
            ViewBag.Genres = genres;
            return View(movie);
        }

        #endregion

        #region Edit - POST

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                var elem = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);

                if (elem != null)
                {
                    elem.Name = movie.Name;
                    elem.ReleaseDate = movie.ReleaseDate;
                    elem.DateAdded = movie.DateAdded;
                    elem.Genre = movie.Genre;

                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
                return View("Index");
            }
        }

        #endregion
    }
}