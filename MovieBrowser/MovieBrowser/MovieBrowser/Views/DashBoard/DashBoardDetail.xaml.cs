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
    public partial class DashBoardDetail : TabbedPage
    {
        DashBoardViewModel _context;
        public DashBoardDetail()
        {
            InitializeComponent();
            _context = DashBoardViewModel.classInstance;
            _context.ShowAllTab += ShowAllTab;
        }

        private void ShowAllTab(ObservableCollection<GenresDetails> GenersList)
        {
            List<string> allContinents = new List<string>();

            // Retrieve and insert all continents from our list
            foreach (var continent in GenersList)
                allContinents.Add(continent.GenerName);

            // Distinct to remove duplicates
            allContinents = allContinents.Distinct().ToList();

            // Create dinamically tabs for continents that we have
            foreach (var continent in allContinents)
            {
                Children.Add(new ItemTab(continent, _context.MovieList, GenersList));
            }
        }
    }
}