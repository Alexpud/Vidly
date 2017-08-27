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
        public List<Movie> movies;

        public MovieController()
        {
            movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Id = 1,
                        Name = "Shrek"
                    },
                    new Movie()
                    {
                        Id = 2,
                        Name = "Children of a Lesser God"
                    }
                };
        }
        // GET: Movie
        public ActionResult Index()
        {

            MovieModel model = new MovieModel();
            model.Movies = this.movies;

            return View(model);
        }

        public ActionResult Details(int movieId)
        {
            var result = movies.FirstOrDefault(x => x.Id == movieId);

            return View(result);
        }
    }
}