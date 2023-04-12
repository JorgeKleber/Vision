﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.NFC;
using Android.Content;

namespace BadgeApp.Droid
{
    [Activity(Label = "BadgeApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

			// Plugin NFC: Initialization before base.OnCreate(...) (Important on .NET MAUI)
			CrossNFC.Init(this);
		}

		protected override void OnResume()
		{
			base.OnResume();

			// Plugin NFC: Restart NFC listening on resume (needed for Android 10+) 
			CrossNFC.OnResume();
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);

			// Plugin NFC: Tag Discovery Interception
			CrossNFC.OnNewIntent(intent);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}