using Acr.UserDialogs;
using MovieBrowser.Interface;
using MovieBrowser.Models.DashBoard;
using MovieBrowser.Utility;
using MovieBrowser.ViewModels.Base;
using MovieBrowser.ViewModels.MovieDetail;
using MovieBrowser.Views;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieBrowser.ViewModels.DashBoard
{
    public class SecondDashBoardViewModel:BaseViewModel
    {
        #region TextAndProperty
        private string continent;
        private MovieDetails _selectedMovie;
        public MovieDetails SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => SelectedMovie);
                SelectMovieCommand?.Execute(SelectedMovie);
            }
        }

        private bool _filter_IsVisible=false;
        public bool Filter_IsVisible
        {
            get { return _filter_IsVisible; }
            set
            {
                _filter_IsVisible = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => Filter_IsVisible);
            }
        }

        private bool _list_IsVisible;
        public bool List_IsVisible
        {
            get { return _list_IsVisible; }
            set
            {
                _list_IsVisible = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => List_IsVisible);
            }
        }

        private bool _isMostRecent;
        public bool IsMostRecent
        {
            get { return _isMostRecent; }
            set
            {
                _isMostRecent = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => IsMostRecent);
                if (IsHighestRated && IsMostRecent)
                {
                    IsHighestRated = !IsMostRecent;
                }
                
            }
        }

        
        private bool _isHighestRated;
        public bool IsHighestRated
        {
            get { return _isHighestRated; }
            set
            {
                _isHighestRated = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => IsHighestRated);
                if (IsHighestRated && IsMostRecent)
                {
                    IsMostRecent = !IsHighestRated;
                }
               
            }
        }



        #endregion
        #region List

        private ObservableCollection<GenresDetails> _genersList;
        public ObservableCollection<GenresDetails> GenersList
        {
            get { return _genersList; }
            set
            {
                _genersList = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => GenersList);

            }
        }

        private ObservableCollection<MovieDetails> _mainMovieList;
        public ObservableCollection<MovieDetails> MainMovieList
        {
            get { return _mainMovieList; }
            set
            {
                _mainMovieList = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => MainMovieList);
            }
        }

        private ObservableCollection<MovieDetails> _movieList;
        public ObservableCollection<MovieDetails> MovieList
        {
            get { return _movieList; }
            set
            {
                _movieList = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => MovieList);
            }
        }
        #endregion

        #region Command
        private ICommand _selectMovieCommand;
        public ICommand SelectMovieCommand
        {
            get
            {
                _selectMovieCommand = _selectMovieCommand ?? new MvxCommand<MovieDetails>(ProcessSelectMovieCommand);
                return _selectMovieCommand;
            }
        }

        private ICommand _openFilterCommand;
        public ICommand OpenFilterCommand
        {
            get
            {
                _openFilterCommand = _openFilterCommand ?? new MvxCommand(ProcessOpenFilterCommand);
                return _openFilterCommand;
            }
        }

       

        private ICommand _cancelFilterCommand;
        public ICommand CancelFilterCommand
        {
            get
            {
                _cancelFilterCommand = _cancelFilterCommand ?? new MvxCommand(ProcessCancelFilterCommand);
                return _cancelFilterCommand;
            }
        }

        private ICommand _applyFilterCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                _applyFilterCommand = _applyFilterCommand ?? new MvxCommand(ProcessApplyFilterCommand);
                return _applyFilterCommand;
            }
        }

        #endregion

        public SecondDashBoardViewModel(string continent, ObservableCollection<MovieDetails> movieList, ObservableCollection<GenresDetails> genersList)
        {
            this.continent = continent;
            this.MainMovieList = movieList;
            this.GenersList = genersList;
            DisplayMovie();
        }

        #region Process Command
        private void DisplayMovie()
        {
            try
            {
                if (MovieList!=null)
                {
                    MovieList.Clear();
                }

                var selectedGenres = GenersList.FirstOrDefault(a => a.GenerName == continent);
                if (selectedGenres.GenerId == 0)
                {
                    MovieList = MainMovieList;
                    return;
                }
                //var List = MainMovieList;
                var ListSelected = MainMovieList.Where(movie => movie.GenreIds.Contains(selectedGenres.GenerId));

                MovieList = new ObservableCollection<MovieDetails>(ListSelected);
            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.Alert(ex.Message, "Apologies", "Ok");
            }
        }

        private async void ProcessSelectMovieCommand(MovieDetails movieDetails)
        {
            try
            {
                var secondPage = new MovieDetailPage(movieDetails);
                //secondPage.BindingContext = movieDetails;
                await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(secondPage));
                //await App.Current.MainPage.Navigation.NavigationStack((new MyNewPage());
                //App.Current.MainPage.Navigation.PushAsync(new MovieDetailPage(viewModel));
                //    var navPar = Mvx.Resolve<INavigationParameter>();
                //    navPar.Parameter = new Tuple<string, object>(MovieBrowserConstants.NavigationParamKeys.SelectedMovie, movieDetails);
                //    //ShowViewModel<MovieDetailViewModel>();
                //    Mvx.Resolve<IMvxNavigationService>().Navigate<MovieDetailViewModel>();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, "", "OK");
            }
        }

        private void ProcessOpenFilterCommand()
        {
            Filter_IsVisible = !Filter_IsVisible;
            if (Filter_IsVisible)
            {
                IsMostRecent = true;
                IsHighestRated = false;
            }
            else
            {
                IsMostRecent = false;
                IsHighestRated = false;
            }
        }

        private void ProcessCancelFilterCommand()
        {
            Filter_IsVisible = false;
        }

        private void ProcessApplyFilterCommand()
        {
            try
            {
                Filter_IsVisible = false;
                if (IsMostRecent)
                {
                    var orderByResult = from singleItem in MovieList
                                        orderby singleItem.ReleaseDate
                                        select singleItem;

                    MovieList = new ObservableCollection<MovieDetails>(orderByResult);
                }
                else
                {
                    var orderByDescendingResult = from singleItem in MovieList
                                                  orderby singleItem.VoteAverage descending
                                                  select singleItem;
                    MovieList = new ObservableCollection<MovieDetails>(orderByDescendingResult);
                }
            }
            catch (Exception)
            {

            }
        }

        
        #endregion
    }
}
