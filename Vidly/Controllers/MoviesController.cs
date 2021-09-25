using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var typeMovie = _context.TypeMovie.ToList();

            var viewModel = new MovieFormViewModel
            {
                TypeMovie = typeMovie
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Index()
        {
            if(User.IsInRole("CanManageMovies"))
                  return View("Index");
            return View("ReadOnlyList");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(c => c.TypeMovie).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {

            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                TypeMovie = _context.TypeMovie.ToList()
            };

            return View("MovieForm", viewModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    TypeMovie = _context.TypeMovie.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdd = DateTime.Now;
                movie.NumberAvailable = movie.Quantdy;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.TypeMovieId = movie.TypeMovieId;
                movieInDb.Quantdy = movie.Quantdy;
                movieInDb.DateReleased = movie.DateReleased;
                movieInDb.NumberAvailable = movie.Quantdy;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }
}