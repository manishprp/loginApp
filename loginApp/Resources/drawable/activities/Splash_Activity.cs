using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginApp.Resources.drawable.activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/Mytheme.splash", MainLauncher = true, NoHistory =true)]
    public class Splash_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
        }
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(Login_Activity));
        }
    }
}