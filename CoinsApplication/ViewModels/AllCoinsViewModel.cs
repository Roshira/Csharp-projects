using CoinsApplication.Models;
using CoinsApplication.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace CoinsApplication.ViewModels
{
    public class AllCoinsViewModel : INotifyPropertyChanged
    {
        private readonly CoinService _coinService;
        private ObservableCollection<CoinCurrency> _allCryptos;
        private ObservableCollection<CoinCurrency> _pagedCryptos;
        private string _searchQuery;
        private int _currentPage;
        private const int PageSize = 15;
        private DispatcherTimer _timer;

        public ObservableCollection<CoinCurrency> PagedCryptos
        {
            get => _pagedCryptos;
            set
            {
                _pagedCryptos = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                {
                    _searchQuery = value;
                    OnPropertyChanged();
                    FilterCoins();
                }
            }
        }
        

        public string CurrentPageText => $"{_currentPage + 1} / {(_allCryptos.Count + PageSize - 1) / PageSize}";

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand SearchCommand { get; }

        public AllCoinsViewModel(CoinService coinService)
        {
            _coinService = coinService;
            _allCryptos = new ObservableCollection<CoinCurrency>();
            PagedCryptos = new ObservableCollection<CoinCurrency>();
            _currentPage = 0;

            NextPageCommand = new RelayCommandService(NextPage, CanGoNext);
            PreviousPageCommand = new RelayCommandService(PreviousPage, CanGoPrevious);
            SearchCommand = new RelayCommandService(FilterCoins);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(1)
            };
            _timer.Tick += async (s, e) => await LoadDataAsync();
            _timer.Start();

            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var data = await _coinService.GetCryptosAsync(500);
                _allCryptos = new ObservableCollection<CoinCurrency>(data);
                FilterCoins();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        public void FilterCoins()
        {
            var filtered = string.IsNullOrWhiteSpace(SearchQuery)
                ? _allCryptos
                : new ObservableCollection<CoinCurrency>(_allCryptos
                    .Where(c => c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                                c.Symbol.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)));

            _currentPage = 0;
            UpdatePagedCryptos(filtered);
        }

        private void UpdatePagedCryptos(ObservableCollection<CoinCurrency> source = null)
        {
            var list = source ?? _allCryptos;
            PagedCryptos = new ObservableCollection<CoinCurrency>(list.Skip(_currentPage * PageSize).Take(PageSize));
            OnPropertyChanged(nameof(CurrentPageText));
        }

        private void NextPage()
        {
            if (_currentPage < (_allCryptos.Count / PageSize))
            {
                _currentPage++;
                UpdatePagedCryptos();
            }
        }

        private void PreviousPage()
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                UpdatePagedCryptos();
            }
        }

        private bool CanGoNext() => _currentPage < (_allCryptos.Count / PageSize);
        private bool CanGoPrevious() => _currentPage > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
