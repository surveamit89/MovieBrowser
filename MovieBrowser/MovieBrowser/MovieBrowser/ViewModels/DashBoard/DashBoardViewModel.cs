using Acr.UserDialogs;
using MovieBrowser.Interface;
using MovieBrowser.Models.DashBoard;
using MovieBrowser.Services;
using MovieBrowser.Utility;
using MovieBrowser.ViewModels.Base;
using MovieBrowser.ViewModels.MovieDetail;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieBrowser.ViewModels.DashBoard
{
    public class DashBoardViewModel : BaseViewModel
    {
        #region  GlobalVAriables
        public static DashBoardViewModel classInstance = new DashBoardViewModel();
        public Action<ObservableCollection<GenresDetails>> ShowAllTab;
        #endregion

        #region LabelAndString
        #endregion

        #region List

        private GenresDetails _selectedGenres;
        public GenresDetails SelectedGenres
        {
            get { return _selectedGenres; }
            set
            {
                _selectedGenres = value;
                NotifyPropertyChanged();
                RaisePropertyChanged(() => SelectedGenres);
                SelectGenresCommand?.Execute(SelectedGenres);
            }
        }


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
        #endregion

        #region Command
        private ICommand _selectGenresCommand;
        public ICommand SelectGenresCommand
        {
            get
            {
                _selectGenresCommand = _selectGenresCommand ?? new MvxCommand<GenresDetails>(ProcessSelectGenresCommand);
                return _selectGenresCommand;
            }
        }

        private ICommand _selectMovieCommand;
        public ICommand SelectMovieCommand
        {
            get
            {
                _selectMovieCommand = _selectMovieCommand ?? new MvxCommand<MovieDetails>(ProcessSelectMovieCommand);
                return _selectMovieCommand;
            }
        }
        #endregion

        #region  Constructor
        public DashBoardViewModel()
        {
            try
            {
                if (CommonUtility.IsConnectedToInternet())
                {
                    ProcessToGetMovieList().GetAwaiter();
                }
                else
                {
                    UserDialogs.Instance.Alert(new AlertConfig
                    {
                        Message = "Please Check Internet Connectivity.",
                        OkText = "OK"

                    });
                }
            }
            catch (Exception ex)
            {
            }
        }

        public DashBoardViewModel(string continent)
        {

            try
            {
                MovieList.Clear();

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
                UserDialogs.Instance.Alert(ex.Message, "Apologies", "Ok");
            }
        }
        #endregion

        #region ProcessCommand
        private async Task ProcessToFetchAllGeners()
        {
            try
            {
                var movieDetailsService = new MovieDetailsService();
                var responce = await movieDetailsService.ProcessToGetGenersListFromServer();
                if (responce != null)
                {
                    if (responce.ListOfGeners != null && responce.ListOfGeners.Count > 0)
                    {
                        GenersList = responce.ListOfGeners;
                        GenresDetails genresDetails = new GenresDetails { GenerId = 0, GenerName = "All" };
                        GenersList.Insert(0, genresDetails);
                    }
                }
                ShowAllTab?.Invoke(GenersList);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, "", "OK");
            }

        }

        private async Task ProcessToGetMovieList()
        {
            try
            {
                var movieDetailsService = new MovieDetailsService();
                var responce = await movieDetailsService.ProcessToGetMovieListFromServer();
                if (responce != null)
                {
                    if (responce.ListOfMovies != null && responce.ListOfMovies.Count > 0)
                    {
                        MovieList = responce.ListOfMovies;
                        foreach (var item in MovieList)
                        {
                            item.ImagePath = MovieBrowserConstants.ImageBaseUrl + item.PosterPath;
                            item.ShowVoteAverage = "IMDb:" + " " + item.VoteAverage;

                        }
                        MainMovieList = MovieList;
                        if (MainMovieList != null)
                        {
                            if (MainMovieList.Count > 0 && SelectedGenres != null)
                            {

                                if (SelectedGenres.GenerId == 0)
                                {
                                    MovieList = MainMovieList;
                                    return;
                                }
                                var List = MainMovieList;
                                var ListSelected = List.Where(movie => movie.GenreIds.Contains(SelectedGenres.GenerId));

                                MovieList = new ObservableCollection<MovieDetails>(ListSelected);
                            }
                        }
                    }
                }


                ProcessToFetchAllGeners().GetAwaiter();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, "", "OK");
            }
        }

        private void ProcessSelectGenresCommand(GenresDetails selectedGenres)
        {
            try
            {
                MovieList.Clear();
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
                UserDialogs.Instance.Alert(ex.Message, "Apologies", "Ok");
            }

        }

        private void ProcessSelectMovieCommand(MovieDetails movieDetails)
        {
            try
            {
                var navPar = Mvx.Resolve<INavigationParameter>();
                navPar.Parameter = new Tuple<string, object>(MovieBrowserConstants.NavigationParamKeys.SelectedMovie, movieDetails);
                //ShowViewModel<MovieDetailViewModel>();
                Mvx.Resolve<IMvxNavigationService>().Navigate<MovieDetailViewModel>();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message, "", "OK");
            }
        }
        #endregion


    }
}
