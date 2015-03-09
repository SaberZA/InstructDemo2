using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Instruct2.Core;

namespace Instruct2.Android
{
    [Activity(Label = "Instruct2.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private ListView _listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            _listView = FindViewById<ListView>(Resource.Id.listViewMovies);

            LoadMovies();
        }

        private async void LoadMovies()
        {
            var movieService = new MovieService();
            var movieList = await movieService.GetTop100MoviesOfAllTime();

            _listView.Adapter = new ArrayAdapter(this, global::Android.Resource.Layout.SimpleListItem1,movieList.Movies);
        }
    }
}

