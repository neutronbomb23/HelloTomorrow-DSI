using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace G5DSI {
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
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

        private void PlayButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            fadeInButton1Animation.Stop(); // Detener la animación fadeInAnimation si aún está en progreso
            fadeOutButton1Animation.Begin(); // Comenzar la animación fadeOutAnimation
        }

        private void PlayButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            fadeOutButton1Animation.Stop(); // Detener la animación fadeOutAnimation si aún está en progreso
            fadeInButton1Animation.Begin(); // Comenzar la animación fadeInAnimation
        }

        private void Button_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                // Obtener el RenderTransform del botón y asegurarse de que es un ScaleTransform
                ScaleTransform scaleTransform = button.RenderTransform as ScaleTransform;
                if (scaleTransform == null) {
                    scaleTransform = new ScaleTransform();
                    button.RenderTransform = scaleTransform;
                }

                // Crear una animación y agregarla al Storyboard
                DoubleAnimation anim = new DoubleAnimation();
                anim.To = 1.15;
                anim.Duration = TimeSpan.FromSeconds(0.3);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(anim);
                Storyboard.SetTarget(anim, scaleTransform);
                Storyboard.SetTargetProperty(anim, "ScaleX");
                Storyboard.SetTargetProperty(anim, "ScaleY");

                // Iniciar la animación del Storyboard
                storyboard.Begin();
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

                // Crear una animación y agregarla al Storyboard
                DoubleAnimation anim = new DoubleAnimation();
                anim.To = 1;
                anim.Duration = TimeSpan.FromSeconds(0.3);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(anim);
                Storyboard.SetTarget(anim, scaleTransform);
                Storyboard.SetTargetProperty(anim, "ScaleX");
                Storyboard.SetTargetProperty(anim, "ScaleY");

                // Iniciar la animación del Storyboard
                storyboard.Begin();
            }
        }
    


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
