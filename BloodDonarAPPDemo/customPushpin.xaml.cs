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
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;



// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BloodDonarAPPDemo
{
    public sealed partial class customPushpin : UserControl
    {
        public customPushpin(detailsofperson dp)
        {
            this.InitializeComponent();
            unameTxt.Text= dp.name;
            distTxt.Text = dp.phone;
            

        }
        public  Geopoint Location { get; set; }
        public customPushpin()
        {
            this.InitializeComponent();
        }

        

        private  async void msgappbar_Click(object sender, RoutedEventArgs e)
         {
            Windows.ApplicationModel.Chat.ChatMessage msg = new Windows.ApplicationModel.Chat.ChatMessage();
            msg.Body = "r u willing to donate blood";
            detailsofperson dof = new detailsofperson();
            msg.Recipients.Add(distTxt.Text);
            await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(msg);
        }

        private void PappbarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(distTxt.Text, unameTxt.Text);
        }

        private void chatappbarbutton_Click(object sender, RoutedEventArgs e)
        {
           // Windows.ApplicationModel.Chat.
        }
    }
}
