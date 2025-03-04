using CoinsApplication.ViewModels;
using CoinsApplication.Services;
using System.Windows.Controls;
using System.Windows;

namespace CoinsApplication.Views
{
    public partial class Top10Coins : Page
    {
        public Top10Coins()
        {
            InitializeComponent();
            DataContext = new Top10CoinsViewModel(new CoinService());
        }
      
    }
}
