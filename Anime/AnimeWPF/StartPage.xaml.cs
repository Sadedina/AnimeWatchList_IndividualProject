using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimeWPF
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            //User is on this Window
            
        }
        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow userPage = new MainWindow();
            userPage.Show();
            this.Close();
        }
        private void ButtonWatchlist_Click(object sender, RoutedEventArgs e)
        {
            WatchListPage watchListPage = new WatchListPage();
            watchListPage.Show();
            this.Close();
        }
        private void ButtonRecomendation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recommendation Feature Comming Soon", "Recomendation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
