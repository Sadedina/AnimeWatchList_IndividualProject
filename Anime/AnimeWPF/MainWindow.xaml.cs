using System;
using System.Diagnostics;
using System.Windows;
using AnimeBusiness;

namespace AnimeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProfileManager _profileManager = new ProfileManager();
        private string _oldUsername;
        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonWatchlist_Click(object sender, RoutedEventArgs e)
        {
            WatchListPage watchListpage = new WatchListPage();
            watchListpage.Show();
            this.Close();
        }
        private void ButtonRecomendation_Click(object sender, RoutedEventArgs e)
        {

        }


        private void EmptyProfileFields()
        {
            TextUsername.Clear();
            TextFirstName.Clear();
            TextLastName.Clear();
            TextAge.Clear();
            TextCountry.Clear();
        }
        private void PopulateListBox()
        {
            ListBoxProfile.ItemsSource = _profileManager.RetrieveAll();
        }
        private void PopulateProfileFields()
        {
            if (_profileManager.SelectedUser != null)
            {
                TextUsername.Text = _profileManager.SelectedUser.Username;
                TextFirstName.Text = _profileManager.SelectedUser.FirstName;
                TextLastName.Text = _profileManager.SelectedUser.LastName;
                TextAge.Text = _profileManager.SelectedUser.Age.ToString();
                TextCountry.Text = _profileManager.SelectedUser.Country;

                _oldUsername = TextUsername.Text;
            }
        }


        private void ListBoxProfile_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxProfile.SelectedItem != null)
            {
                _profileManager.SetSelectedUser(ListBoxProfile.SelectedItem);

                Trace.WriteLineIf(ListBoxProfile.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
                PopulateProfileFields();
            }
        }


        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            //Create(string username, string firstName, string lastName, int age, string country)
            _profileManager.Create(
                  username: TextUsername.Text
                , firstName: TextFirstName.Text
                , lastName: TextLastName.Text
                , age: Convert.ToInt32(TextAge.Text)
                , country: TextCountry.Text);

            ListBoxProfile.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            EmptyProfileFields();
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Update(string oldUsername, string username, string firstName, string lastName, int age, string country)
            _profileManager.Update(
                oldUsername: _oldUsername
                , username: TextUsername.Text
                , firstName: TextFirstName.Text
                , lastName: TextLastName.Text
                , age: Convert.ToInt32(TextAge.Text)
                , country: TextCountry.Text);

            ListBoxProfile.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            EmptyProfileFields();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete(string username)
            _profileManager.Delete(username: TextUsername.Text);

            ListBoxProfile.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            EmptyProfileFields();
        }
    }
}