using MoviesTool.Core.DbModel;
using MoviesTool.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Core.Interfaces
{
    public interface IDataServices
    {
        Task<List<FavoriteMovie>> GetFavoriteMovies();

        Task<bool> AddFavoriteMovie(Movie movie);

        Task<bool> RemoveFavoriteMovie(Movie movie);
    }
}
