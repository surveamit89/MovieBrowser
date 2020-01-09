using MovieBrowser.Models.DashBoard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MovieBrowser.Models.ServiceResponse
{
    public class GenersBaseResponse
    {
        [JsonProperty("genres")]
        public ObservableCollection<GenresDetails> ListOfGeners { get; set; }
    }
}
