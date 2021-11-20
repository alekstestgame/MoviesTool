using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesTool.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public bool IsAdault {get;set;}

        public string Title { get; set; }

        public string Description { get; set; }

        public string Poster { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public List<GenreViewModel> Genres { get; set; }

        public int Runtime { get; set; }

        public long Budget { get; set; }

        public string Homepage { get; set; }
    }
}
