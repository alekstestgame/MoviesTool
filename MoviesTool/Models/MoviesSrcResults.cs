using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesTool.Web.Models
{
    public class MoviesSrcResults
    {
        public int Page { get; set; }

        public List<MovieViewModel> Movies { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }

    }
}
