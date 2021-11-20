using Microsoft.AspNetCore.Mvc;
using MoviesTool.Core.Interfaces;
using MoviesTool.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesTool.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }


        [HttpGet()]
        public async Task<IActionResult> ListTopRatedMovies()
        {
            var popMovies = await movieService.GetRatedMoviesAsync(1);

            var dto = new MoviesSrcResults
            {
                Page = popMovies.Page,
                Movies = popMovies.Results.Select(x => new MovieViewModel() { Id = x.Id, Title = x.OriginalTitle, Description = x.Overview, Poster = x.PosterPath }).ToList(),
                TotalPages = popMovies.TotalPages,
                TotalResults = popMovies.TotalResults
            };

            return View(dto);
        }

        public IActionResult MyFavoriteMovies()
        {


            return View();
        }
    }
}
