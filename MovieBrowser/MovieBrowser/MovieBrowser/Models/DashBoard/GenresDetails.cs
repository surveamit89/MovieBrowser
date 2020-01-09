using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBrowser.Models.DashBoard
{
    public class GenresDetails
    {
        [JsonProperty("id")]
        public int GenerId { get; set; }

        [JsonProperty("name")]
        public string GenerName { get; set; }
    }
}
