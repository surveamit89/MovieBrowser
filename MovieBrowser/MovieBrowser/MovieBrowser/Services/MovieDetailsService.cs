using Acr.UserDialogs;
using MovieBrowser.Models.ServiceResponse;
using MovieBrowser.Utility;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Services
{
    public class MovieDetailsService : BaseWebService
    {
        public async Task<MovieBaseResponse> ProcessToGetMovieListFromServer()
        {
            try
            {
                var request = new RestRequest(MovieBrowserConstants.RestAPI.Movie);

                var response = await ExecuteGet<MovieBaseResponse>(request, true);

                if (response != null)
                {

                    return response;

                }
                return response;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                return null;
            }
        }

        public async Task<MovieBaseResponse> ProcessToSearchMovieListFromServer(string SearchText)
        {
            try
            {
                var request = new RestRequest(MovieBrowserConstants.RestAPI.Search);
                request.AddOrUpdateQueryParameter(MovieBrowserConstants.RestRequestsKeys.Query, SearchText);

                var response = await ExecuteGet<MovieBaseResponse>(request, true);

                if (response != null)
                {

                    return response;

                }
                return response;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                return null;
            }
        }

        public async Task<GenersBaseResponse> ProcessToGetGenersListFromServer()
        {

            try
            {
                var request = new RestRequest(MovieBrowserConstants.RestAPI.Genres);

                var response = await ExecuteGet<GenersBaseResponse>(request, true);

                if (response != null)
                {

                    return response;

                }
                return response;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                return null;
            }
        }
    }
}
