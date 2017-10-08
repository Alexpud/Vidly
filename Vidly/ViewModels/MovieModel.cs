using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public Movie movie {get;set;}
        public int MovieId { get; set; }
    }
}