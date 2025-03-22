using CoinsApplication.ViewModels;
using CoinsApplication.Services;
using System.Windows.Controls;
using System.Windows;
using CoinsApplication.Models;

namespace CoinsApplication.Views
{
    public partial class Top10Coins : Page
    {
        public Top10Coins()
        {
            InitializeComponent();
            UpdateLocalization();
            DataContext = new Top10CoinsViewModel(new CoinService());
        }

        public void UpdateLocalization()
        {
            Top10Title.Text = Properties.Resources.Top10Cryptocurrencies;
            NameColumn.Header = Properties.Resources.NameColumn;
            SymbolColumn.Header = Properties.Resources.SymbolColumn;
            PriceColumn.Header = Properties.Resources.PriceColumn;
            MarketCapColumn.Header = Properties.Resources.MarketCapColumn;
            Change1hColumn.Header = Properties.Resources.Сhange1hColumn;
            Change24hColumn.Header = Properties.Resources.Change24hColumn;
            Change7dColumn.Header = Properties.Resources.Change7dColumn;
        }
        private void CryptosListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCoin = CryptosListView.SelectedItem as CoinCurrency;
            if (selectedCoin != null)
            {
                var coinDetailsPage = new CoinDetailsPage(selectedCoin);
                NavigationService.Navigate(coinDetailsPage);
            }
        }
    }
}
