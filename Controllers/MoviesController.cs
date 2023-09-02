using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Data;
using Practica.WebAPI.Controllers.Data.Interfaces;
using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            return Ok(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = MovieExists(id);
            return Ok(movie);
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
            _movieRepository.CreateMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie updatedMovie)
        {
            var movie = MovieExists(id);
            if (movie != null)
            {
                movie.Description = updatedMovie.Description;
                movie.Duration = updatedMovie.Duration;
                movie.Gender = updatedMovie.Gender;
                _movieRepository.UpdateMovie(movie);
                return NoContent();
            }
            return NotFound();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = MovieExists(id);
            if (movie != null)
            {
                _movieRepository.DeleteMovie(id);
                return NoContent();
            }
            return NotFound();
        }

        private Movie MovieExists(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            return movie;
        }
    }
}
