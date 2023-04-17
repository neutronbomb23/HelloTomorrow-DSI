using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Pickers;
using Windows.Storage;
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
        MainPage mainPage;
        private BitmapImage customCursorImage;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            customCursorImage = new BitmapImage(new Uri("ms-appx:///Assets/rocket.png"));
        }


        public Settings()
        {
            this.InitializeComponent();
            //mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/space.mp3"));
            //mediaPlayer.Play();
            //mediaPlayer.Volume = 0.5;
            //Cargo canción
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaPlayer.Volume = e.NewValue / 100.0;


        }


        private void brillo_Changed_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MG.Opacity = e.NewValue / 100.0;
            if (MG.Opacity < 0.2)
            {
                MG.Opacity = 0.2;
            }
            //mainPage.Opacity = MG.Opacity;
        }

        private async void ElegirCancionButton_Click(object sender, RoutedEventArgs e)
        {
            #region cancion personalizada
            //// Crear un objeto FileOpenPicker
            //FileOpenPicker picker = new FileOpenPicker();
            //picker.ViewMode = PickerViewMode.Thumbnail;
            //picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            //picker.FileTypeFilter.Add(".mp3");

            //// Mostrar el diálogo de selección de archivo
            //StorageFile file = await picker.PickSingleFileAsync();

            //if (file != null)
            //{
            //    // Reproducir la canción seleccionada
            //    MediaElement mediaElement = new MediaElement();
            //    mediaElement.SetSource(await file.OpenAsync(FileAccessMode.Read), file.ContentType);
            //    mediaElement.Play();
            //}
            #endregion

            #region cancion assets
            // Declarar la variable file al inicio del método
            StorageFile file = null;

            // Obtener la carpeta Assets y las canciones disponibles
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            var files = await folder.GetFilesAsync();
            var canciones = files.Where(f => f.FileType == ".mp3").ToList();

            // Asignar la lista de canciones al ListView
            ListViewSongs.ItemsSource = canciones.Select(f => f.DisplayName).ToList();

            // Mostrar la lista de canciones y esperar a que el usuario seleccione una
            var dialog = new ContentDialog
            {
                Title = "Seleccionar canción",
                Content = new ListBox { ItemsSource = canciones.Select(f => f.DisplayName).ToList() },
                PrimaryButtonText = "Reproducir",
                SecondaryButtonText = "Cancelar"
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                // Obtener el archivo de la canción seleccionada
                var selectedFile = canciones[(dialog.Content as ListBox).SelectedIndex];

                // Reproducir la canción seleccionada
                var mediaElement = new MediaElement();
                mediaElement.SetSource(await selectedFile.OpenAsync(FileAccessMode.Read), selectedFile.ContentType);
                mediaElement.Play();
            }

            #endregion
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
