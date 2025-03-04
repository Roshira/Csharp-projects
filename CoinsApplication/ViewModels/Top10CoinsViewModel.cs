using CoinsApplication.Models;
using CoinsApplication.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CoinsApplication.ViewModels
{
    public class Top10CoinsViewModel : INotifyPropertyChanged
    {
        private readonly CoinService _coinService;
        private ObservableCollection<CoinCurrency> _cryptos;
        private DispatcherTimer _timer;

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

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(60); 
            _timer.Tick += Timer_Tick;
            _timer.Start();

            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var data = await _coinService.GetCryptosAsync(10); 
                Cryptos = new ObservableCollection<CoinCurrency>(data);
            }
            catch (Exception ex)
            {
                // Error logging (you can add a logger or show a message)
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Update data every 15 seconds
            await LoadDataAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}