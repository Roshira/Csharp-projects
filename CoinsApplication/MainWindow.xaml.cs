using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Threading;
using CoinsApplication.Properties;
using CoinsApplication.Views;

namespace CoinsApplication
{
    public partial class MainWindow : Window
    {
        private bool _isDarkTheme = false;
        private bool _isEnglish = true;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Top10Coins());
            UpdateLocalization();
        }

        private void BtnTop10Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Top10Coins());
        }

        private void AllCoins1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllCoins());
        }

        private void LoadTheme(string themePath)
        {
            ResourceDictionary newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void BtnSwitchThemeClick(object sender, RoutedEventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;
            LoadTheme(_isDarkTheme ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml");
        }

        private void UpdateLocalization()
        {
            var culture = new CultureInfo(_isEnglish ? "en-US" : "uk-UA");
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // Оновлення тексту кнопок
            BtnTop10.Content = Properties.Resources.BtnTop10;
            AllCoins.Content = Properties.Resources.AllCoins;

            // Оновлення тексту на сторінках
            if (MainFrame.Content is Top10Coins top10Page)
            {
                top10Page.UpdateLocalization();
            }
            else if (MainFrame.Content is AllCoins allCoinsPage)
            {
                allCoinsPage.UpdateLocalization();
            }
        }
        private void SwitchLanguageClick(object sender, RoutedEventArgs e)
        {
            _isEnglish = !_isEnglish;
            UpdateLocalization();
        }
    }
}