using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Views.DashBoard
{

    public class DashBoardMasterMenuItem
    {
        public DashBoardMasterMenuItem()
        {
            TargetType = typeof(DashBoardMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}