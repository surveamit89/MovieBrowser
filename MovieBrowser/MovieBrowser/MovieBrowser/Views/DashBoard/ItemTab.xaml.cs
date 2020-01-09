using MovieBrowser.Models.DashBoard;
using MovieBrowser.ViewModels.DashBoard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieBrowser.Views.DashBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemTab : ContentPage
    {
        public ItemTab(string continent)
        {
            InitializeComponent();
            Title = continent;
        }

        public ItemTab(string continent, ObservableCollection<MovieDetails> movieList, ObservableCollection<GenresDetails> genersList)
        {
            try
            {
                InitializeComponent();
                Title = continent;
                BindingContext = new SecondDashBoardViewModel(continent, movieList, genersList);
            }
            catch (Exception es)
            {

            }
        }
    }
}