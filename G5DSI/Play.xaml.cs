﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace G5DSI {
    public sealed partial class Play : Page {
        public int coins = 1500;
        public int electricity = 50;
        public int water = 50;
        public int minerals = 50;
        public int militar = 50;
        public int people = 200;

        private int metaValor = 100; // establecer la meta en 100%
        private int valorActual = 0; // establecer el valor actual en 0%
        private DispatcherTimer timer;

        public Play() {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            progressBar.ValueChanged += ProgressBar_ValueChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            valorCoins.Text = coins.ToString();
            valorElectricidad.Text = electricity.ToString();
            valorAgua.Text = water.ToString();
            valorCristales.Text = minerals.ToString();
            if (electricity == 0) {
                ShowPopupElectricity();
            }
            if (water == 0){
                ShowPopupWater();
            }
            if (militar == 0){
                ShowPopupMinerals();
            }
            progressBar.Value = valorActual;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start(); ;
        }


        private  void Timer_Tick(object sender, object e)
        {
            // calcular la cantidad de incremento en función de la duración de transición y la meta
            int incremento = (int)((metaValor - valorActual) * 0.01 * 10);

            // si el incremento es cero, establecer el valor en la meta y restablecer el valor actual y la meta
            if (incremento == 0) { //crecen las personas
                progressBar.Value = metaValor;
                valorActual = 0;

                // generar una nueva meta aleatoria diferente de la meta actual
                int nuevaMeta = new Random().Next(0, 101);
                while (nuevaMeta == metaValor)
                {
                    nuevaMeta = new Random().Next(0, 101);
                }
                metaValor = nuevaMeta;
            }
            // de lo contrario, actualizar el valor de la ProgressBar y el valor actual
            else
            {
                progressBar.Value += incremento;
                valorActual += incremento;
            }

            // Actualizar el color de fondo de la ProgressBar
            if (valorActual > metaValor)
            {
                progressBar.Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                progressBar.Background = new SolidColorBrush(Colors.Green);
            }
        }
        private async void ShowPopupElectricity()
        {
            ContentDialog popup = new ContentDialog()
            {
                Title = "Aviso Urgente",
                Content = "Te quedaste sin suministro de electricidad, POV: de un niño camerunés.\n¡Has perdido!",
                PrimaryButtonText = "closeButton"
            };
            var result = await popup.ShowAsync();
        }

        private async void ShowPopupWater()
        {
            ContentDialog popup = new ContentDialog()
            {
                Title = "Aviso Urgente",
                Content = "Te quedaste sin agua, tus colonos han muerto de ser, como los africanos. \n ¡Has perdido!",
                PrimaryButtonText = "closeButton"
            };
            var result = await popup.ShowAsync();
        }

        private async void ShowPopupMinerals()
        {
            ContentDialog popup = new ContentDialog()
            {
                Title = "Aviso Urgente",
                Content = "Te quedaste sin minerales, no has podido fabricar suficientes armas y los Gurond te han invadido. \n ¡Has perdido!",
                PrimaryButtonText = "closeButton"
            };
            var result = await popup.ShowAsync();
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

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Play playPage = this; // Obtener la instancia de la página Play
            Frame.Navigate(typeof(Shop), playPage); // Navegar a la página Shop y pasar la instancia de la página Play como parámetro
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
            var listBox = new ListBox { ItemsSource = new List<string> { "Settings", "Controls", "Menu" }, Style = (Style)Resources["CustomDialogListBoxStyle"] };

            var dialog = new ContentDialog
            {
                Title = "Acciones",
                Content = listBox,
                PrimaryButtonText = "Settings",
                SecondaryButtonText = "Controls",
                CloseButtonText = "Menu",
                Style = (Style)Resources["CustomContentDialogStyle"],
                PrimaryButtonStyle = (Style)Resources["CustomDialogContentButtonStyle"],
                SecondaryButtonStyle = (Style)Resources["CustomDialogContentButtonStyle"],
                CloseButtonStyle = (Style)Resources["CustomDialogContentButtonStyle"]
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