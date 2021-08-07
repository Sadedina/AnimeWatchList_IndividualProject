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
            Username_Populate();
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


        private void Username_Populate()
        {
            foreach (var item in _profileManager.RetrieveUsername())
            {
                usernameList.Items.Add(item);
            }
        }
        private void Username_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextInfoSum.Text = "";
            TextInfoName.Content = "";
            WatchlistSpecificForUser.Items.Clear();
            var listBox = (ListBox)sender;
            if (listBox != null && listBox.SelectedValue != null)
            {
                _username = listBox.SelectedValue.ToString();
                NewAnimeListToChooseFrom_Populate();
                WatchlistSpecificForUser_Populate(_username);
            }
        }
        private void NewAnimeListToChooseFrom_Populate()
        {
            newAnimeListToChooseFrom.Items.Clear();
            foreach (var item in _watchlistManager.RetrieveOtherAnimes(_username))
            {
                newAnimeListToChooseFrom.Items.Add(item.AnimeName);
            }
        }
        private void WatchlistSpecificForUser_Populate(string username)
        {
            foreach (var item in _watchlistManager.RetrieveAnimeDetailsGivenUsername(username))
            {
                WatchlistSpecificForUser.Items.Add(item.AnimeName);
            }
        }
        private void NewAnimeListToChooseFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextInfoName.Content = "";
            TextInfoSum.Text = "";
            //_watchlistManager.SetSelectedAnimeForInfo(ListBoxAnimeWatchlistForUser.SelectedItem);

            if (newAnimeListToChooseFrom.SelectedItem != null)
            {
                var list = _watchlistManager.RetrieveAllAnimesForSpecialList(newAnimeListToChooseFrom.SelectedItem.ToString());

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
                Trace.WriteLineIf(newAnimeListToChooseFrom.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
            }
        }

        private void WacthlistSpecificForUser_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (WatchlistSpecificForUser.SelectedItem != null)
            {
                var list = _watchlistManager.RetrieveAnimeDetailsGivenUser(WatchlistSpecificForUser.SelectedItem.ToString());
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
                Trace.WriteLineIf(WatchlistSpecificForUser.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
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
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ////Delete(string username)
            //_profileManager.Delete(username: TextUsername.Text);

            //ListBoxProfile.ItemsSource = null;
            //// put back the screen data
            //PopulateListBox();
            //ListBoxProfile.SelectedItem = _profileManager.SelectedUser;
            //EmptyProfileFields();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
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