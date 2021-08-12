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
        private string _anime;
        private string _animeToDelete;
        private string _watching = "reset";
        private int? _rating = -1;
        public WatchListPage()
        {
            InitializeComponent();
            Username_Populate();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            StartPage startPage = new StartPage();
            startPage.Show();
            this.Close();
        }
        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow userPage = new MainWindow();
            userPage.Show();
            this.Close();
            
        }
        private void ButtonWatchlist_Click(object sender, RoutedEventArgs e)
        {
            //User is on this Window
        }
        private void ButtonRecomendation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recommendation Feature Comming Soon", "Recomendation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetFieldsOnClick()
        {
            //_watching = "restart";
            //_rating = -2;
            TextInfoSum.Text = "";
            TextInfoName.Content = "";
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
            ResetFieldsOnClick();
            _anime = null;
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
            WatchlistSpecificForUser.Items.Clear();
            var list = _watchlistManager.RetrieveAnimeDetailsGivenUsername(username);

            foreach (var item in list)
            {
                WatchlistSpecificForUser.Items.Add($"Name: {item.AnimeName}\nStatus: {item.Watching}\nRating: {item.Rating}");
                //WatchlistSpecificForUser.Items.Add(item.AnimeName);
            }
        }
        private void NewAnimeListToChooseFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetFieldsOnClick();


            if (newAnimeListToChooseFrom.SelectedItem != null)
            {
                _watching = "reset";
                _rating = -1;

                var list = _watchlistManager.RetrieveAllAnimes(newAnimeListToChooseFrom.SelectedItem.ToString());

                foreach (var item in list)
                {
                    TextInfoName.Content = $"Rank: {item.Rank}" +
                    $"\nTitle: {item.AnimeName}" +
                    $"\nGenre: {item.Genre}" +
                    $"\nEpisode: {item.Episode}" +
                    $"\nYear: {item.ReleaseYear}" +
                    $"\nStatus: {item.Status}";
                    TextInfoSum.Text = $"SUMMARY\n{item.Summary}";
                    _anime = item.AnimeName;
                }
                Trace.WriteLineIf(newAnimeListToChooseFrom.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
            }
        }

        private void WacthlistSpecificForUser_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ResetFieldsOnClick();
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
                    _anime = item.AnimeName;
                    _animeToDelete = item.AnimeName;
                }
                Trace.WriteLineIf(WatchlistSpecificForUser.SelectedItem.ToString().Contains("BLOG"), $"BLOG was selected");
            }
        }

        private void ListBoxRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ratingsListBox.SelectedItem != null)
            {
                var value = ((ListBoxItem)ratingsListBox.SelectedValue).Content.ToString();
                if (value == "reset")
                {
                    _rating = -1;
                }
                else
                {
                    _rating = Convert.ToInt32(((ListBoxItem)ratingsListBox.SelectedValue).Content.ToString());
                }
            }
        }
        private void ListBoxWatched_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (watchedeListBox.SelectedItem != null)
            {
                _watching = ((ListBoxItem)watchedeListBox.SelectedValue).Content.ToString();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            _watchlistManager.CreateOrUpdateRating(username: _username, animeTitle: _anime, rating: _rating);
            _watchlistManager.CreateOrUpdateWatching(username: _username, animeTitle: _anime, watching: _watching);
            NewAnimeListToChooseFrom_Populate();
            WatchlistSpecificForUser_Populate(_username);
        }
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _watchlistManager.CreateOrUpdateRating(username: _username, animeTitle: _anime, rating: _rating);
            _watchlistManager.CreateOrUpdateWatching(username: _username, animeTitle: _anime, watching: _watching);
            NewAnimeListToChooseFrom_Populate();
            WatchlistSpecificForUser_Populate(_username);
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            _watchlistManager.Delete( _username, _animeToDelete);
            NewAnimeListToChooseFrom_Populate();
            WatchlistSpecificForUser_Populate(_username);
        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Request for Anime Feature Comming Soon", "Request", MessageBoxButton.OK, MessageBoxImage.Information);
        }

     


    }
}