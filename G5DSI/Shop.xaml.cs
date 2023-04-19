using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace G5DSI
{
    public sealed partial class Shop : Page
    {
        bool cambiado1 = false;
        Play play;
        public Shop()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            
        }


        private Play playPage;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is Play)
            {
                playPage = e.Parameter as Play;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Play), playPage);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
   
            playPage.number1 -= 1;
            playPage.number2 -= 1;
            playPage.number3 -= 1;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            playPage.number1 -= 2;
            playPage.number2 -= 2;
            playPage.number3 -= 2;
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {

            playPage.number1 -= 5;
            playPage.number2 -= 5;
            playPage.number3 -= 5;
        }
    }
}
