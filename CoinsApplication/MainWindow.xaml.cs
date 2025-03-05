using CoinsApplication.Views;
using System.Windows;
using System.Windows.Controls;

namespace CoinsApplication
{
    public partial class MainWindow : Window
    {
        private bool isDarkTheme = false;
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
        private void LoadTheme(string themePath)
        {
            ResourceDictionary newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void BtnSwitchTheme_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            LoadTheme(isDarkTheme ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml");
        }
    }
}
