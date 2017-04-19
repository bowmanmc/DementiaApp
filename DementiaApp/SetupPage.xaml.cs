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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DementiaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetupPage : Page
    {
        public SetupPage()
        {
            this.InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to MainPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(MainPage));
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SetupUserPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupUserPage));
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SetupPatientPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupPatientPage));
        }

        private void btnQuestions_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SetupQuestionsPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupQuestionsPage));
        }
    }
}
