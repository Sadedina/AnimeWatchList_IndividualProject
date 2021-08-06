using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using AnimeBusiness;
using System.Windows.Controls;

namespace AnimeWPF
{
    /// <summary>
    /// Interaction logic for WatchListPage.xaml
    /// </summary>
    public partial class WatchListPage : Window
    {
        private WatchListManager _watchlistManager = new WatchListManager();
        private AnimeManager _animeManager = new AnimeManager();
        private ProfileManager _profileManager = new ProfileManager();

        public WatchListPage()
        {
            InitializeComponent();
            PopulateUsernameComboBox();
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


        private void PopulateUsernameComboBox()
        {
            foreach (var item in _profileManager.RetrieveUsername())
            {
                usernameComboBox.Items.Add(item);
            }
        }
        private void usernameComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox != null && comboBox.SelectedValue != null)
            {
                PopulateAnimeBox(comboBox.SelectedValue.ToString());
            }

        }
        private void PopulateAnimeBox(string username)
        {
            var Userid = _profileManager.RetrieveUserId(username);

            foreach (var item in _watchlistManager.RetrieveAllUsersAnime(Userid))
            {
                ListBoxAnime.Items.Add(item);
            }
        }
        



        private void ListBoxAnime_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //if (ListBoxAnime.SelectedItem != null)
            //{
            //    _watchlistManager.SetSelectedWatchlist(ListBoxAnime.SelectedItem);

            //    Trace.WriteLineIf(ListBoxAnime.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
            //    PopulateListBox();
            //}
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

        private void ratingsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void watchedeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void animeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}