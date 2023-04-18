using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace G5DSI
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Play : Page {
        public Play() {
            this.InitializeComponent();

            progressBar.ValueChanged += ProgressBar_ValueChanged;
        }
        private DispatcherTimer timer;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Inicializar el temporizador
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            // Generar un valor aleatorio en el rango entre 0 y 100
            int newValue = new Random().Next(0, 101);

            // Actualizar el valor de la ProgressBar
            progressBar.Value = newValue;
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Shop));
        }
        private void ProgressBar_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            // Si el valor de la ProgressBar sube, se vuelve verde
            if (e.NewValue > e.OldValue)
            {
                progressBar.Background = new SolidColorBrush(Colors.Green);
            }
            // Si el valor de la ProgressBar baja, se vuelve amarilla
            else if (e.NewValue < e.OldValue)
            {
                progressBar.Background = new SolidColorBrush(Colors.Yellow);
            }
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

        private async void ElegirCancionButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog
            {
                Title = "Acciones",            
                PrimaryButtonText = "Settings",
                SecondaryButtonText = "Controls",
                CloseButtonText = "Menu"
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(Settings));
            }
            else if (result == ContentDialogResult.Secondary)
            {
                Frame.Navigate(typeof(Controls));
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

    }
}
