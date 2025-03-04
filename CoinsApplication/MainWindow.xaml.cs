using CoinsApplication.Views;
using System.Windows;
using System.Windows.Controls;

namespace CoinsApplication
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Top10Coins());
        }

        private void BtnTop10_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Top10Coins());
        }

        private void AllCoins_(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllCoins());
        }
    }
}
