using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Core.Objects
{
    public class Movie
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        //[JsonProperty("alternative_titles")]
        //public AlternativeTitles AlternativeTitles { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        //[JsonProperty("belongs_to_collection")]
        //public SearchCollection BelongsToCollection { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }


        //[JsonProperty("budget")]
        //public long Budget { get; set; }

        //[JsonProperty("changes")]
        //public ChangesContainer Changes { get; set; }

        //[JsonProperty("credits")]
        //public Credits Credits { get; set; }


        //[JsonProperty("homepage")]
        //public string Homepage { get; set; }

    }
}
