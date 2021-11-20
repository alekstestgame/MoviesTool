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
        readonly IMovieService movieService;
        readonly IDataServices dataServices;

        public MovieController(IMovieService movieService, IDataServices dataServices)
        {
            this.movieService = movieService;
            this.dataServices = dataServices;
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

        [HttpGet()]
        public async Task<IActionResult> MyFavoriteMovies()
        {
            var myFavoriteMvs = await dataServices.GetFavoriteMovies();

            return View();
        }
    }
}
