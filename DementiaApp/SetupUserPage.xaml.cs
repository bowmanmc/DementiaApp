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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DementiaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetupUserPage : Page
    {

        private String USER_FILE = "user.txt";

        public SetupUserPage()
        {
            this.InitializeComponent();
            this.loadUserFromStorage();
        }

        private void btnSetup_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to SetupPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupPage));
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Saving2 user...");
            User user = new DementiaApp.User();
            user.Name = txtName.Text;
            user.Email = txtEmail.Text;
            Debug.WriteLine("User: " + user.ToJson());

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile userFile = await storageFolder.CreateFileAsync(USER_FILE, Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(userFile, user.ToJson());            

            this.loadUserFromStorage();
        }

        private async void loadUserFromStorage()
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile userFile = await storageFolder.GetFileAsync(USER_FILE);

                String userJson = await Windows.Storage.FileIO.ReadTextAsync(userFile);
                User u = User.FromJson(userJson);
                Debug.WriteLine("Read stored user: " + u.ToString());
                txtEmail.Text = u.Email;
                txtName.Text = u.Name;
            }
            catch
            {
                Debug.WriteLine("Exception trying to read file " + USER_FILE);
            }
        }
    }
}
