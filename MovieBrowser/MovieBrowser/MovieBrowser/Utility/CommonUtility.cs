using Acr.UserDialogs;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieBrowser.Utility
{
    public class CommonUtility
    {
        public static bool IsConnectedToInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        public async static Task UnAuthorisedPopUp(object sender, string unAuthMsg, bool isFromResend = false)
        {
            await Task.Delay(100);
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Message = "Access denied !!",
                OkText = "OK"

            });
        }

        public  static void InternetErrorPopUp(object sender, string unAuthMsg, bool isFromResend = false)
        {
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Message = "Please Check Internet Connectivity.",
                OkText = "OK"

            });
        }

    }
}
