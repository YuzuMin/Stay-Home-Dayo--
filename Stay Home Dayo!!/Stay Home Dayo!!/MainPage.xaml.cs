using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;

using System.IO;
using System.Reflection;

public interface IAudioService
{
    void PlayAudioFile(string filename);
}

namespace Stay_Home_Dayo__
{


    public partial class MainPage : ContentPage
    {
        int lblValue = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_clicked(object sender, EventArgs e)
        { 
            DependencyService.Get<IAudioService>().PlayAudioFile("stayhome.mp3");
            lblValue++;
            lblCount.Text = lblValue.ToString();

        }
    }
}

