using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBrowser.Utility
{
    public class MovieBrowserConstants
    {
        public const string APIKeyValue = "93b257810f916a349fa53dcd7c319069";
        public const string LanguageCodeValue = "en-US";
        public const string ImageBaseUrl = "https://image.tmdb.org/t/p/w500";

        public static class RestAPI
        {
            public static readonly string Search = "search/multi";
            public static readonly string Movie = "discover/movie";
            public static readonly string Genres = "genre/movie/list";
        }

        public static class NavigationParamKeys
        {
            public static string SelectedMovie = "selectedMovie";
            public static string SelectedGenres = "selectedGenres";
        }

        public static class RestRequestsKeys
        {
            public static readonly string APIKey = "api_key";
            public static readonly string LanguageCode = "language";
            public static readonly string Query = "query";
        }

        
    }
}
