using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace WWCD
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var page = new Xamarin.Forms.NavigationPage(new MainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#2196F3")
            };
            page.On<iOS>().SetPrefersLargeTitles(true);

            MainPage = page;
		}
	}
}
