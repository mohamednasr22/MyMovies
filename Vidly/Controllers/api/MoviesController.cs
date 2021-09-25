using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        //Get /api/Movies
        public IEnumerable<MovieDto> GetMovie(string query=null)
        {
            var moviesquery =
                 _context.Movie.Include(c => c.TypeMovie)
                 .Where(c => c.NumberAvailable > 0);
            if(!String.IsNullOrWhiteSpace(query))
                moviesquery = moviesquery.Where(m => m.Name.Contains(query));

             return moviesquery
             .ToList()
             .Select(Mapper.Map<Movie, MovieDto>);
        }


        //Get /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie= _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }



        //Post /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            movieDto.NumberAvailable = movieDto.Quantdy;
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movie.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        //Edit /api/Movies/id
        [HttpPut]
        public void EditMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb=_context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb== null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieInDb,movieInDb);

            _context.SaveChanges();

        }


        // DELETE /api/customers/1 IHttpActionResult
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
           
        }

    }
}
