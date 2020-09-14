
using Android.Media;
using Xamarin.Forms;
using Stay_Home_Dayo__.Droid;
using Java.Security;
using Android.OS;

[assembly: Dependency(typeof(AudioRender))]
namespace Stay_Home_Dayo__.Droid
{
    public class AudioRender : IAudioService
    {
        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var file = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.SetDataSource(file.FileDescriptor, file.StartOffset, file.Length);
            player.Prepared += (s, e) =>{player.Start();};
            player.Prepare();            
        }

    }
    
}