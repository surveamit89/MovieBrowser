using MovieBrowser.Models.DashBoard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieBrowser.Models.ServiceResponse
{
    public class MovieBaseResponse
    {
        [JsonProperty("page")]
        public int PageNo { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public ObservableCollection<MovieDetails> ListOfMovies { get; set; }
    }
}
