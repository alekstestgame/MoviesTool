using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Core.DbModel
{
    public class FavoriteMovie
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

    }
}
