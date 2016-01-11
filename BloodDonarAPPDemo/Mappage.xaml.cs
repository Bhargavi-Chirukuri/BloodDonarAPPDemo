using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BloodDonarAPPDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Mappage : Page
    {
        public Mappage()
        {
            this.InitializeComponent();
            //customPushpin cc = new customPushpin();
            

        }
        List<detailsofperson> allusers = new List<detailsofperson>();
        Geolocator g1 = new Geolocator();
        Geoposition gp;
        MapIcon myPOI;
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            gp = await g1.GetGeopositionAsync();
            Geopoint m1 = gp.Coordinate.Point;
            MapIcon mypoi = new MapIcon { Location = m1, NormalizedAnchorPoint = new Point(0.5, 1.0), Title =  "my loc", ZIndex = 0 };
            mymap.MapElements.Add(mypoi);
            mymap.ZoomLevel = 15;
            mymap.Center = m1;

            allusers = await App.MobileService.GetTable<detailsofperson>().ToListAsync();
            int count = 0;
            foreach(detailsofperson det in allusers)
            {
                Geopoint mypoint = new Geopoint(new BasicGeoposition { Latitude = Convert.ToDouble(det.lat), Longitude = Convert.ToDouble(det.lng) });
                 myPOI = new MapIcon { Location = mypoint, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = ++count+"", ZIndex = 0 };
                // add to map and center it
                // myPOI = new MapIcon { Location = myPoint, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = "My position", ZIndex = 0 };
                mymap.MapElements.Add(myPOI);
  
            }
            
        }

        private void mymap_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var pos = e.GetPosition(mymap);
           

            //BasicGeoposition bg = new BasicGeoposition
            //{
            //    Latitude = Math.Round(pos.Position.Latitude, 4),
            //    Longitude = Math.Round(pos.Position.Longitkkude, 4)
            //};

            //Geolocator gl = new Geolocator();

            //Geopoint gpp = 
            //mymap.GetLocationFromOffset(pos, out gpp);

           

           
        }

        private void mymap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var pos = args.Location;
            BasicGeoposition bg = new BasicGeoposition
            {
                Latitude = Math.Round(pos.Position.Latitude,4),
                Longitude = Math.Round(pos.Position.Longitude,4)
            };

            
            getDataFromCloud(bg);

            
            

           // mymap.MapElements.Add(cP);
        }


        private async void getDataFromCloud(BasicGeoposition bg)
        {
            try
            {

                List<detailsofperson> tappeduser = new List<detailsofperson>();

                  tappeduser = await App.MobileService.GetTable<detailsofperson>().Where(X => bg.Latitude.ToString()== X.lat & bg.Longitude.ToString()==X.lng).ToListAsync();
                customPushpin cc = new customPushpin();
                
                mymap.Children.Add(new customPushpin(tappeduser[0]));
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception" + ex);
            }


        }
    }
    }

