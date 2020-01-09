using MovieBrowser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBrowser.Helper
{
    public class NavigationParameter : INavigationParameter
    {
        public Tuple<string, object> Parameter { get; set; }
        public List<Tuple<string, object>> Parameters { get; set; }
    }
}
