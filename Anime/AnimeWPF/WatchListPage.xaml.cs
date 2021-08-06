using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using AnimeBusiness;

namespace AnimeWPF
{
    /// <summary>
    /// Interaction logic for WatchListPage.xaml
    /// </summary>
    public partial class WatchListPage : Window
    {
        public WatchListPage()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindowPage = new MainWindow();
            mainWindowPage.Show();
            this.Close();
        }
        private void ButtonWatchlist_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonRecomendation_Click(object sender, RoutedEventArgs e)
        {

        }

        private WatchListManager _watchlistManager = new WatchListManager();

        private void PopulateListBox()
        {
            ListBoxAnime.ItemsSource = _watchlistManager.RetrieveAll();
        }

        private void PopulateAnimeFields()
        {
            if (_watchlistManager.SelectedWatchlist != null)
            {
                //TextUsername.Text = _watchlistManager.SelectedUser.Username;
                //TextFirstName.Text = _watchlistManager.SelectedUser.FirstName;
                //TextLastName.Text = _watchlistManager.SelectedUser.LastName;
                //TextAge.Text = _watchlistManager.SelectedUser.Age.ToString();
                //TextCountry.Text = _watchlistManager.SelectedUser.Country;

            }
        }

        private void ListBoxAnime_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxAnime.SelectedItem != null)
            {
                _watchlistManager.SetSelectedWatchlist(ListBoxAnime.SelectedItem);

                Trace.WriteLineIf(ListBoxAnime.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
                PopulateListBox();
            }
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            //Create(string username, string firstName, string lastName, int age, string country)
            //_profileManager.Create(
            //      username: TextUsername.Text
            //    , firstName: TextFirstName.Text
            //    , lastName: TextLastName.Text
            //    , age: Convert.ToInt32(TextAge.Text)
            //    , country: TextCountry.Text);

            //ListBoxProfile.ItemsSource = null;
            //// put back the screen data
            //PopulateListBox();
            //ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            //EmptyProfileFields();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            ////Update(string oldUsername, string username, string firstName, string lastName, int age, string country)
            //_profileManager.Update(
            //    oldUsername: _oldUsername
            //    , username: TextUsername.Text
            //    , firstName: TextFirstName.Text
            //    , lastName: TextLastName.Text
            //    , age: Convert.ToInt32(TextAge.Text)
            //    , country: TextCountry.Text);

            //ListBoxProfile.ItemsSource = null;
            //// put back the screen data
            //PopulateListBox();
            //ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            //EmptyProfileFields();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ////Delete(string username)
            //_profileManager.Delete(username: TextUsername.Text);

            //ListBoxProfile.ItemsSource = null;
            //// put back the screen data
            //PopulateListBox();
            //ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            //EmptyProfileFields();
        }

        private void ListBoxInformation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}