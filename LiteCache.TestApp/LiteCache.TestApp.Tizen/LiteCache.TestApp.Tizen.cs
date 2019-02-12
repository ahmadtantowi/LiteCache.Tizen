using LiteCache.Tizen;
using System;
using Xamarin.Forms;

namespace LiteCache.TestApp
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Cotton.CacheDirectory = DependencyService.Get<IDirectory>().ApplicationPath();
            Cotton.Current.Create("Greetings", "This is yarn inside cotton!", TimeSpan.FromDays(1));

            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            app.Run(args);
        }
    }
}
