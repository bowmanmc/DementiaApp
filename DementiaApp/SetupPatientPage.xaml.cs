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
    public sealed partial class SetupPatientPage : Page
    {
        public SetupPatientPage()
        {
            this.InitializeComponent();
            this.loadPatientFromStorage();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to SetupPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupPage));
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Saving patient...");
            Patient patient = new DementiaApp.Patient();
            patient.Name = txtName.Text;
            patient.Age = Convert.ToInt16(txtAge.Text);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile patientFile = await storageFolder.CreateFileAsync("patient.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(patientFile, patient.ToJson());
        }

        private async void loadPatientFromStorage()
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile patientFile = await storageFolder.GetFileAsync("patient.txt");

                String patientJson = await Windows.Storage.FileIO.ReadTextAsync(patientFile);

                Patient p = Patient.FromJson(patientJson);
                Debug.WriteLine("Loaded patient: " + p.ToString());

                txtName.Text = p.Name;
                txtAge.Text = p.Age.ToString();
            }
            catch
            {
                Debug.WriteLine("Couldn't read patient.txt file");
            }
        }
    }
}
