using LiteCache.Tizen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LiteCache.TestApp
{
    public class App : Application
    {
        public App()
        {
			Cotton.CacheDirectory = DependencyService.Get<IDirectory>().ApplicationPath();
			Cotton.Current.Create("Hi", "This is yarn inside cotton!", TimeSpan.MaxValue);

			// The root page of your application
			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						new Label
						{
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "LiteCache data: " + Cotton.Current.Read("Hi")
						}
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
