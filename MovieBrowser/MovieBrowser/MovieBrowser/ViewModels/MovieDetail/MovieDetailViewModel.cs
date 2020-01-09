using MovieBrowser.Interface;
using MovieBrowser.Models.DashBoard;
using MovieBrowser.Utility;
using MovieBrowser.ViewModels.Base;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBrowser.ViewModels.MovieDetail
{
    public class MovieDetailViewModel:BaseViewModel
    {
        #region  GlobalVAriables
        #endregion

        #region Labels
        #endregion

        #region StringPropertyAndList

        private MovieDetails _movieDetail;
        public MovieDetails MovieDetails
        {
            get { return _movieDetail; }
            set
            {
                _movieDetail = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => MovieDetails);
            }
        }

        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                _ImagePath = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => ImagePath);
            }
        }

        private string _title;
        public string MovieTitle
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => MovieTitle);
            }
        }

        private string _overview;
        public string Overview
        {
            get { return _overview; }
            set
            {
                _overview = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => Overview);
            }

        }

        private string _userRating;
        public string UserRating
        {
            get { return _userRating; }
            set
            {
                _userRating = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => UserRating);
            }

        }

        private string _releaseDate;
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => ReleaseDate);
            }

        }


        #endregion

        #region Command
        #endregion

        #region  Constructor
        public MovieDetailViewModel()
        {
            try
            {
                var navPar = Mvx.Resolve<INavigationParameter>();
                if (navPar != null)
                {
                    if (navPar.Parameter != null)
                    {
                        if (navPar.Parameter.Item1.Equals(MovieBrowserConstants.NavigationParamKeys.SelectedMovie))
                        {
                            MovieDetails = navPar.Parameter.Item2 as MovieDetails;
                            ImagePath = MovieDetails.ImagePath;
                            Overview = MovieDetails.Overview;
                            MovieTitle = MovieDetails.MovieTitle;
                            UserRating = MovieDetails.ShowVoteAverage;
                            ReleaseDate = "Release Date : " + MovieDetails.ReleaseDate.ToShortDateString();
                        }
                    }
                }
            }
            catch (Exception es)
            {
            }
        }

        public MovieDetailViewModel(MovieDetails movieDetails)
        {
            try
            {
                MovieDetails = movieDetails;
                ImagePath = MovieDetails.ImagePath;
                Overview = MovieDetails.Overview;
                MovieTitle = MovieDetails.MovieTitle;
                UserRating = MovieDetails.ShowVoteAverage;
                ReleaseDate = "Release Date : " + MovieDetails.ReleaseDate.ToShortDateString();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region ProcessCommand
        #endregion
    }
}
