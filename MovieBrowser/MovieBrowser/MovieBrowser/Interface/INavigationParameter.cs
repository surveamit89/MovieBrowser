using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBrowser.Interface
{
    public interface INavigationParameter
    {
        Tuple<string, object> Parameter { get; set; }
        List<Tuple<string, object>> Parameters { get; set; }
    }
}
