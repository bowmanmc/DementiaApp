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
    public sealed partial class SetupQuestionsPage : Page
    {

        private String QUESTIONS_FILE = "questions.txt";

        public SetupQuestionsPage()
        {
            this.InitializeComponent();
            this.loadQuestionsFromStorage();
        }

        private void btnSetup_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to SetupPage
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(SetupPage));
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Saving questions...");
            QuestionList qList = new QuestionList();
            String[] questions = new String[3];
            questions[0] = txtQuestion1.Text;
            questions[1] = txtQuestion2.Text;
            questions[2] = txtQuestion3.Text;
            qList.Questions = new List<String>(questions);

            Debug.WriteLine("Questions: " + qList.ToJson());

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile questionsFile = await storageFolder.CreateFileAsync(QUESTIONS_FILE, Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(questionsFile, qList.ToJson());

            this.loadQuestionsFromStorage();
        }

        private async void loadQuestionsFromStorage()
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile questionsFile = await storageFolder.GetFileAsync(QUESTIONS_FILE);

                String questionsJson = await Windows.Storage.FileIO.ReadTextAsync(questionsFile);
                QuestionList questionsList = DementiaApp.QuestionList.FromJson(questionsJson);
                Debug.WriteLine("Read stored questions: " + questionsList.ToJson());

                txtQuestion1.Text = questionsList.Questions[0];
                txtQuestion2.Text = questionsList.Questions[1];
                txtQuestion3.Text = questionsList.Questions[2];
            }
            catch
            {
                Debug.WriteLine("Exception trying to read file " + QUESTIONS_FILE);
            }
        }
    }
}
