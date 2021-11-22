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
        IServiceProvider serviceProvider;

        public DbDataServices(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
            
        }

        public async Task<bool> AddFavoriteMovie(Movie movie)
        {
            try
            {
                dbContext.Add(new FavoriteMovie() { MovieId = movie.Id });
                var saveResult = await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return true;
        }

        public async Task<List<FavoriteMovie>> GetFavoriteMovies()
        {
            return await dbContext.FavoriteMovies.ToListAsync();
        }

        public async Task<bool> RemoveFavoriteMovie(Movie movie)
        {
            try
            {
                dbContext.Remove(new FavoriteMovie() { MovieId = movie.Id });
                var saveResult = await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return true;
        }
    }
}
