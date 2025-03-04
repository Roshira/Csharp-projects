using CoinsApplication.Models;
using CoinsApplication.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CoinsApplication.ViewModels
{
    public class Top10CoinsViewModel : INotifyPropertyChanged
    {
        private readonly CoinService _coinService;
        private ObservableCollection<CoinCurrency> _cryptos;

        public ObservableCollection<CoinCurrency> Cryptos
        {
            get => _cryptos;
            set
            {
                _cryptos = value;
                OnPropertyChanged();
            }
        }

        public Top10CoinsViewModel(CoinService coinService)
        {
            _coinService = coinService;
            Cryptos = new ObservableCollection<CoinCurrency>();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var data = await _coinService.GetCryptosAsync(10);
            Cryptos = new ObservableCollection<CoinCurrency>(data);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
