using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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
                valorCoins.Text = playPage.coins.ToString();
                valorElectricidad.Text = playPage.electricity.ToString();
                valorAgua.Text = playPage.water.ToString();
                valorCristales.Text = playPage.minerals.ToString();
                valorMilitar.Text = playPage.militar.ToString();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Play));
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

        private void BuyElectricity(int coins, int e)
        {
            if (playPage.coins - coins >= 0)
            {
                playPage.coins -= coins;
                valorCoins.Text = playPage.coins.ToString();

                playPage.electricity += e;
                valorElectricidad.Text = playPage.electricity.ToString();
            }
        }
        private void BuyWater(int coins, int e)
        {
            if (playPage.coins - coins >= 0)
            {
                playPage.coins -= coins;
                valorCoins.Text = playPage.coins.ToString();

                playPage.water += e;
                valorAgua.Text = playPage.water.ToString();
            }
        }

        private UIElement _draggedElement;
        private Point _draggedElementOffset;

        private void OnDraggableItemPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var element = (UIElement)sender;
            var pointer = e.GetCurrentPoint(element);
            _draggedElementOffset = pointer.Position;
            element.CapturePointer(e.Pointer);
            _draggedElement = element;

            _draggedElementId = element.GetValue(FrameworkElement.TagProperty) as string; // Asume que el ID se almacena en la propiedad Tag del elemento
        }


        private string _draggedElementId; // Agregue esta línea

        protected override void OnPointerMoved(PointerRoutedEventArgs e)
        {
            base.OnPointerMoved(e);

            if (_draggedElement != null)
            {
                var pointer = e.GetCurrentPoint(redCanvas);
                Canvas.SetLeft(_draggedElement, pointer.Position.X - _draggedElementOffset.X);
                Canvas.SetTop(_draggedElement, pointer.Position.Y - _draggedElementOffset.Y);
            }
        }

        protected override void OnPointerReleased(PointerRoutedEventArgs e)
        {
            base.OnPointerReleased(e);

            if (_draggedElement != null)
            {
                _draggedElement.ReleasePointerCaptures();
                _draggedElement = null;
            }
        }
        private void BuyMinerals(int coins, int e)
        {
            if (playPage.coins - coins >= 0)
            {
                playPage.coins -= coins;
                valorCoins.Text = playPage.coins.ToString();

                playPage.minerals += e;
                valorCristales.Text = playPage.minerals.ToString();
            }
        }
        private void BuyPeople(int coins, int e)
        {
            if (playPage.coins - coins >= 0)
            {
                playPage.coins -= coins;
                valorCoins.Text = playPage.coins.ToString();

                playPage.people += e;
                valorPersonas.Text = playPage.people.ToString();
            }
        }
        private void BuyMilitar(int coins, int e)
        {
            if (playPage.coins - coins >= 0)
            {
                playPage.coins -= coins;
                valorCoins.Text = playPage.coins.ToString();

                playPage.militar += e;
                valorMilitar.Text = playPage.militar.ToString();
            }
        }

        private async void redCanvas_Drop(object sender, DragEventArgs e)
        {
                switch (_draggedElementId)
                {
                    case "peo1":
                        BuyPeople(10, 1);
                        break;
                    case "peo2":
                        BuyPeople(1, 100);
                        // Código para manejar el segundo elemento
                        break;
                case "peo3":
                    BuyPeople(3, 8);
                    break;
                case "wat1":
                    BuyWater(10, 1);
                    break;
                case "wat2":
                    BuyWater(1,100);
                    break;
                case "wat3":
                    BuyWater(3, 8);
                    break;
                case "elec1":
                    BuyElectricity(10, 1);
                    break;
                case "elec2":
                    BuyElectricity(1, 100);
                    break;
                case "elec3":
                    BuyElectricity(3, 8);
                    break;
                case "min1":
                    BuyMinerals(10, 1);
                    break;
                case "min2":
                  BuyMinerals(1, 100);
                    break;
                case "min3":
                    BuyMinerals(3, 8); 
                    break;
                case "arm1":
                    BuyMilitar(3, 8);
                    break;
                case "arm2":
                    BuyMilitar(1, 100);
                    break;
                case "arm3":
                    BuyMilitar(2, 4);
                    break;
                default:
                        break;
                        // Agrega más casos según sea necesario
                }       
        }



        private void redCanvas_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.IsCaptionVisible = false;
            e.DragUIOverride.IsContentVisible = false;
            e.DragUIOverride.IsGlyphVisible = false;
        }

    }
}
