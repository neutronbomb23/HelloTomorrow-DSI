using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace G5DSI {
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    public sealed partial class MainPage : Page {

        MediaPlayer mediaPlayer = new MediaPlayer();
        private Settings settings = new Settings();
        MainPage mainPage;

        public double VOLUMENGENERAL { get; set; }
        
        public MainPage() {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            VOLUMENGENERAL = 0.4;
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/LaVieEnRose.mp3"));
            mediaPlayer.Volume = 0.0;
            mediaPlayer.Play();

        }

        private void Settings_Click(object sender, RoutedEventArgs e) {
     

            // Navegar a la página que desea modificar el volumen y pasar el objeto MediaPlayer como parámetro
            Frame.Navigate(typeof(Settings), mediaPlayer);

           
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null && e.Parameter is Settings)
            {
                settings = e.Parameter as Settings;
            }

            if (settings != null && mediaPlayer != null && settings.cambiado)
            {
                mediaPlayer.Pause();
            }

            if (settings != null && mainPage != null)
            {
                mainPage.Opacity = Opacity;
            }
        }




        private void Controls_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Controls));
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        { 
            Frame.Navigate(typeof(Play));
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            fadeOutAnimation.Begin();
        }

        private void myTextBlock_PointerEntered(object sender, PointerRoutedEventArgs e){
            fadeInAnimation.Stop(); // Detener la animación fadeInAnimation si aún está en progreso
            fadeOutAnimation.Begin(); // Comenzar la animación fadeOutAnimation
        }

        private void myTextBlock_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            fadeOutAnimation.Stop(); // Detener la animación fadeOutAnimation si aún está en progreso
            fadeInAnimation.Begin(); // Comenzar la animación fadeInAnimation
        }

        private void Button_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Obtener el RenderTransform del botón y asegurarse de que es un ScaleTransform
                ScaleTransform scaleTransform = button.RenderTransform as ScaleTransform;
                if (scaleTransform == null)
                {
                    // Configurar el ScaleTransform para que el botón comience en tamaño 1 y centrado
                    scaleTransform = new ScaleTransform() { CenterX = 0.5, CenterY = 0.5 };
                    button.RenderTransformOrigin = new Point(0.5, 0.5);
                    button.RenderTransform = scaleTransform;
                }

                // ANIM 1
                DoubleAnimation anim = new DoubleAnimation();
                anim.To = 1.15;
                anim.Duration = TimeSpan.FromSeconds(0.1);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(anim);
                Storyboard.SetTarget(anim, scaleTransform);
                Storyboard.SetTargetProperty(anim, "ScaleX");

                // ANIM 2
                DoubleAnimation anim2 = new DoubleAnimation();
                anim2.To = 1.15;
                anim2.Duration = TimeSpan.FromSeconds(0.1);
                Storyboard storyboard2 = new Storyboard();
                storyboard2.Children.Add(anim2);
                Storyboard.SetTarget(anim2, scaleTransform);
                Storyboard.SetTargetProperty(anim2, "ScaleY");

                // Ajustar las animaciones para que se expanda en todas las direcciones
                anim.From = anim2.From = 1;
                anim.To = anim2.To = 1.15;

                // Iniciar la animación del Storyboard
                storyboard.Begin();
                storyboard2.Begin();
            }
        }

        private void Button_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e){
            Button button = sender as Button;
            if (button != null) {
                // Obtener el RenderTransform del botón y asegurarse de que es un ScaleTransform
                ScaleTransform scaleTransform = button.RenderTransform as ScaleTransform;
                if (scaleTransform == null) {
                    scaleTransform = new ScaleTransform();
                    button.RenderTransform = scaleTransform;
                }

                // ANIM 1
                DoubleAnimation anim = new DoubleAnimation();
                anim.To = 1;
                anim.Duration = TimeSpan.FromSeconds(0.1);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(anim);
                Storyboard.SetTarget(anim, scaleTransform);
                Storyboard.SetTargetProperty(anim, "ScaleX");

                // Iniciar la animación del Storyboard
                storyboard.Begin();

                // ANIM 2
                DoubleAnimation anim2 = new DoubleAnimation();
                anim2.To = 1;
                anim2.Duration = TimeSpan.FromSeconds(0.1);
                Storyboard storyboard2 = new Storyboard();
                storyboard2.Children.Add(anim2);
                Storyboard.SetTarget(anim2, scaleTransform);
                Storyboard.SetTargetProperty(anim2, "ScaleY");

                // Iniciar la animación del Storyboard
                storyboard2.Begin();
            }
        }
    


        private void Exit_Click(object sender, RoutedEventArgs e){
            CoreApplication.Exit();
        }


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e){

        }
    }
}
