using MvvmCross.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieBrowser.Models.DashBoard
{
    public class MovieDetails
    {
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("video")]
        public bool IsVideo { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("title")]
        public string MovieTitle { get; set; }

        [JsonProperty("popularity")]
        public double MoviePopularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("adult")]
        public bool IsAdultContent { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public string ShowVoteAverage { get; set; }

        [JsonIgnore]
        public ICommand SelectMovieCommand { get; set; }


        private ICommand _movieSelectedCommand;
        public ICommand MovieSelectedCommand
        {
            get
            {
                return _movieSelectedCommand ?? (_movieSelectedCommand = new MvxCommand(ProcessCarModelCommand));
            }
        }

        private void ProcessCarModelCommand()
        {
            SelectMovieCommand?.Execute(this);
        }
    }
}
