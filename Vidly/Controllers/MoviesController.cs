using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movie.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m=>m.Id==id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);

        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}
            };
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name="Shrek!!"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };

          
            return View(viewModel);
            // ViewData["Movie"] = movie;
            // return View(movie);

            //  return new ViewResult();
            // return Content("HelloWorld");


            // return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        //movies
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageindex={0}&sortBy={1}",pageIndex,sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            return Content(year+"/"+month);
        }
    }
}