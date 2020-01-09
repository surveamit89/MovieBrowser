using MovieBrowser.Models.DashBoard;
using MovieBrowser.ViewModels.DashBoard;
using MovieBrowser.ViewModels.MovieDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieBrowser.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage()
        {
            InitializeComponent();
           
        }

        public MovieDetailPage(MovieDetails movieDetails)
        {
            InitializeComponent();
            BindingContext = new MovieDetailViewModel(movieDetails);
        }
    }
}