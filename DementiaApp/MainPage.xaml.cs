using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DementiaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            User u = new DementiaApp.User();
            Debug.WriteLine("User {0} created at {1}", u.Id, u.DateCreated);
            u.Name = "Michael Bowman";
            u.Email = "michael.bowman3005@sinclair.edu";

            Debug.WriteLine(u);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the About Page
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(AboutPage));
        }
    }
}
