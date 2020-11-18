using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using Xamarin.Forms;
using Stay_Home_Dayo__.Droid;
using Java.Security;

[assembly: Dependency(typeof(AudioRender))]

namespace Stay_Home_Dayo__.Droid
{
    [Activity(Label = "Stay_Home_Dayo__", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    public class AudioRender : IAudioService
    {
        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var file = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.SetDataSource(file.FileDescriptor, file.StartOffset, file.Length);
            player.Prepared += (s, e) => { player.Start(); };
            player.Prepare();
  
        }

    }

}