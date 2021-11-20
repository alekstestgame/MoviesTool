using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesTool.Core.DbModel;
using MoviesTool.Core.Interfaces;
using MoviesTool.Core.Objects;
using MoviesTool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Common.Services
{
    public class DbDataServices : IDataServices
    {
        ApplicationDbContext dbContext;
        public DbDataServices(IServiceProvider serviceProvider)
        {
            this.dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public Task<bool> AddFavoriteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FavoriteMovie>> GetFavoriteMovies()
        {
            return await dbContext.FavoriteMovies.ToListAsync();
        }

        public Task<bool> RemoveFavoriteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
