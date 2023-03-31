using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace G5DSI
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        private BitmapImage customCursorImage;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            customCursorImage = new BitmapImage(new Uri("ms-appx:///Assets/rocket.png"));
        }


        public Settings()
        {

            this.InitializeComponent();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/strong.mp3"));
            mediaPlayer.Play();
            mediaPlayer.Volume = 0.0;
            //Cargo canción
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaPlayer.Volume = e.NewValue / 100.0;
        }


        private void brillo_Changed_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            imi.Opacity = e.NewValue / 100.0;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.TryGoBack();
            mediaPlayer.Pause();
        }

        public static bool TryGoBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }



    }
}
