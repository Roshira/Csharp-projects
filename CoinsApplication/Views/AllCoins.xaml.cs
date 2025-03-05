using CoinsApplication.Services;
using CoinsApplication.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinsApplication.Views
{
    /// <summary>
    /// Interaction logic for AllCoins.xaml
    /// </summary>
    public partial class AllCoins : Page
    {
        public AllCoins()
        {
            InitializeComponent();
            UpdateLocalization();
            DataContext = new AllCoinsViewModel(new CoinService());
        }

        public void UpdateLocalization()
        {
            AllCoinsNameColumn.Header = Properties.Resources.NameColumn;
            AllCoinsSymbolColumn.Header = Properties.Resources.SymbolColumn;
            AllCoinsPriceColumn.Header = Properties.Resources.PriceColumn;
            AllCoinsMarketCapColumn.Header = Properties.Resources.MarketCapColumn;
            AllCoinsChange1hColumn.Header = Properties.Resources.Сhange1hColumn;
            AllCoinsChange24hColumn.Header = Properties.Resources.Change24hColumn;
            AllCoinsChange7dColumn.Header = Properties.Resources.Change7dColumn;
            PreviousButton.Content = Properties.Resources.PreviousButton;
            NextButton.Content = Properties.Resources.NextButton;
        }
    }
}
