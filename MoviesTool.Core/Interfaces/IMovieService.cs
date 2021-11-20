using MoviesTool.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Core.Interfaces
{
    public interface IMovieService
    {
        Task GetAllAsync();

        Task<SearchResults<Movie>> GetAllPopularAsync(int page);

        Task<Movie> GetMovieByIdAsync(int id);
    }
}
