using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TanksController
{
    public static class GlobalData
    {
        public static IPAddress SelectedIP;
        public static int SelectedTankIndex;
        public static string PlayerName;
        public static List<string> Tanks;
        public static List<string> Names;
    }
}