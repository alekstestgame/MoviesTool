using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesTool.Core.Interfaces;
using MoviesTool.Core.Objects;
using MoviesTool.Models;
using MoviesTool.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService movieService;
        readonly IDataServices dataServices;
        SearchResults<Movie> searchResults;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, IDataServices dataServices)
        {
            _logger = logger;
            this.movieService = movieService;
            this.dataServices = dataServices;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var popMovies = await movieService.GetAllPopularAsync(1);

            var dto = new MoviesSrcResults
            {
                Page = popMovies.Page,
                Movies = popMovies.Results.Select(x => new MovieViewModel() { Id = x.Id, Title = x.OriginalTitle, Description = x.Overview, Poster = x.PosterPath }).ToList(),
                TotalPages = popMovies.TotalPages,
                TotalResults = popMovies.TotalResults
            };

            return View(dto);
        }


        [Route("Home/Index/{page?}")]
        public async Task<IActionResult> Index(int page=1)
        {
            //var popMovies = await movieService.GetAllPopularAsync(page);
            searchResults = await movieService.GetAllPopularAsync(page);

            //int nextPage = popMovies.Page + 1;

            var dto = new MoviesSrcResults
            {
                Page = searchResults.Page,
                Movies = searchResults.Results.Select(x => new MovieViewModel() { Id = x.Id, Title = x.OriginalTitle, Description = x.Overview, Poster = x.PosterPath }).ToList(),
                TotalPages = searchResults.TotalPages,
                TotalResults = searchResults.TotalResults
            };

            return View(dto);
        }

        [Route("Home/MovieDetails/{id?}")]
        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);

            var dto = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Overview,
                Poster = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                Budget = movie.Budget,
                Homepage = movie.Homepage,
                Genres = movie.Genres.Select(x=> new GenreViewModel() { Id = x.Id, Name = x.Name}).ToList()
            };


            return View(dto);
        }

        public async Task<IActionResult> AddToFavorite(MovieViewModel movieModel)
        {
            string ff = "";

            var addFav = dataServices.AddFavoriteMovie(new Movie() { Id = movieModel.Id });



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
