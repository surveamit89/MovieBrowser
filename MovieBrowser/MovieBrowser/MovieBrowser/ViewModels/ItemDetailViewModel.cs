using System;

using MovieBrowser.Models;
using MovieBrowser.ViewModels.Base;

namespace MovieBrowser.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            //Title = item?.Text;
            //Item = item;
        }
    }
}
