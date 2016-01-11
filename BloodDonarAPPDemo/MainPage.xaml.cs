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
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BloodDonarAPPDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        Geolocator g1 = new Geolocator();
        Geoposition gp;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
             gp = await g1.GetGeopositionAsync();
            latlong.Text = Math.Round(gp.Coordinate.Point.Position.Latitude, 4).ToString() + "," + Math.Round(gp.Coordinate.Point.Position.Longitude, 4).ToString();
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            detailsofperson d = new detailsofperson
            {
                name = nametxt.Text,
                phone = phonetxt.Text,
                lat=Math.Round( gp.Coordinate.Point.Position.Latitude,4).ToString(),
                lng=Math.Round( gp.Coordinate.Point.Position.Longitude,4).ToString()
            };

            await App.MobileService.GetTable<detailsofperson>().InsertAsync(d);

            var m1 = new MessageDialog("Data Inserted").ShowAsync();

            nametxt.Text = "";

            phonetxt.Text = "";
            latlong.Text = "";
            //this.Frame.Navigate(typeof(Mappage));
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if(nametxt.Text=="sai")
            {
                string s = nametxt.Text;
                this.Frame.Navigate(typeof(Mappage),s);
            }
        }
    }
}
