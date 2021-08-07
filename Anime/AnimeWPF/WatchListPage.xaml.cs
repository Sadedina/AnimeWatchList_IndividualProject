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
        private string _username;
        public WatchListPage()
        {
            InitializeComponent();
            PopulateUsername();
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


        private void PopulateUsername()
        {
            foreach (var item in _profileManager.RetrieveUsername())
            {
                usernameList.Items.Add(item);
            }
        }
        private void ListBoxUsernames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxAnimeWatchlistForUser.Items.Clear();
            var listBox = (ListBox)sender;
            if (listBox != null && listBox.SelectedValue != null)
            {
                _username = listBox.SelectedValue.ToString();
                PopulateAnimeListBoxSuggestionForUser();
                PopulateAnimeBoxInformation(_username);
            }
        }
        private void PopulateAnimeListBoxSuggestionForUser()
        {
            animeListBoxSummaryAtBottom.Items.Clear();
            foreach (var item in _watchlistManager.RetrieveOtherAnimes(_username))
            {
                animeListBoxSummaryAtBottom.Items.Add(item);
            }
        }
        private void PopulateAnimeBoxInformation(string username)
        {
            foreach (var item in _watchlistManager.RetrieveAnimeDetailsGivenUsername(username))
            {
                ListBoxAnimeWatchlistForUser.Items.Add(item.AnimeName);
            }
        }

        private void AnimeListBoxSummary_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            animeListBoxSummaryAtBottom.Items.Clear();
            //_watchlistManager.SetSelectedAnimeForInfo(ListBoxAnimeWatchlistForUser.SelectedItem);
            

            if (ListBoxAnimeWatchlistForUser.SelectedItem != null)
            {
                var list = _watchlistManager.RetrieveAnimeDetailsGivenUser(ListBoxAnimeWatchlistForUser.SelectedItem.ToString());
                foreach (var item in list)
                {
                    TextInfoName.Content = $"Rank: {item.Rank}" +
                    $"\nTitle: {item.AnimeName}" +
                    $"\nGenre: {item.Genre}" +
                    $"\nEpisode: {item.Episode}" +
                    $"\nYear: {item.ReleaseYear}" +
                    $"\nStatus: {item.Status}";
                    TextInfoSum.Text = $"SUMMARY\n{item.Summary}";
                }
                Trace.WriteLineIf(ListBoxAnimeWatchlistForUser.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
            }
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

        private void ListBoxRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxWatched_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}