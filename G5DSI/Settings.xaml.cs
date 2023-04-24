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
        
        private BitmapImage customCursorImage;
        private MainPage mainPage;
        private MediaPlayer mediaPlayer;
        private MediaElement mediaElement1 = new MediaElement();
        private MediaElement mediaElement = new MediaElement();
        private MediaPlayer mediaPlayer1;
        public double opacity = 1;
        double mecagoentodo;
        public bool cambiado { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is MediaPlayer)
            {
                mediaPlayer = e.Parameter as MediaPlayer;
            }

            if (e.Parameter is MainPage)
            {
                mainPage = e.Parameter as MainPage;
            }
        }



        public Settings()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mecagoentodo = e.NewValue / 100.0;

            if (mediaPlayer != null)
            {
                mediaPlayer.Volume = e.NewValue / 100.0;
            }
            if (cambiado) { mecagoentodo = e.NewValue / 100.0; mediaElement1.Volume = mecagoentodo;/* mediaElement.Volume = mediaPlayer1.Volume;*/ }
            
        }


        private void brillo_Changed_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            opacity = e.NewValue / 100.0;
            if (Opacity < 0.2)
            {
                Opacity = 0.2;
            }
            MG.Opacity= opacity;    

        }

        private async void ElegirCancionButton_Click(object sender, RoutedEventArgs e)
        {
           

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
                Content = new ListBox { ItemsSource = canciones.Select(f => f.DisplayName).ToList(), Style = (Style)Resources["CustomDialogListBoxStyle"] },
                PrimaryButtonText = "Reproducir",
                SecondaryButtonText = "Cancelar",
                Style = (Style)Resources["CustomContentDialogStyle"],
                PrimaryButtonStyle = (Style)Resources["CustomDialogContentButtonStyle"],
                SecondaryButtonStyle = (Style)Resources["CustomDialogContentButtonStyle"]
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                cambiado = true;
                // Obtener el archivo de la canción seleccionada
                var selectedFile = canciones[(dialog.Content as ListBox).SelectedIndex];

                // Reproducir la canción seleccionada
                mediaPlayer.Pause();
                mediaElement.Pause();
                mediaElement1.SetSource(await selectedFile.OpenAsync(FileAccessMode.Read), selectedFile.ContentType);
                mediaElement1.Volume = mecagoentodo;
                mediaElement1.Play();
            }

            #endregion
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            Settings settings = this; // Obtener la instancia de la página Play

            Frame.Navigate(typeof(MainPage), settings);

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

        private async void ElegirCancionPersonalizada_Click(object sender, RoutedEventArgs e)
        {
            #region cancion personalizada
            // Crear un objeto FileOpenPicker
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            picker.FileTypeFilter.Add(".mp3");

            // Mostrar el diálogo de selección de archivo
            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                cambiado = true;
                mediaPlayer.Pause();
                mediaElement1.Pause();
                // Reproducir la canción seleccionada
                
                mediaElement.SetSource(await file.OpenAsync(FileAccessMode.Read), file.ContentType); 
                
                mediaElement.Play();
               
            }
            #endregion
        }
    }
}
