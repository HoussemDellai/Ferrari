using GalaSoft.MvvmLight.Messaging;

namespace Ferrari.ViewModels
{
    public class SplashScreenPageViewModel : BaseViewModel
    {
        private int _loadedDataLevel;

        public int LoadedDataLevel
        {
            get { return _loadedDataLevel; }
            set
            {
                _loadedDataLevel = value;
                OnPropertyChanged();
            }
        }

        public SplashScreenPageViewModel()
        {
            Messenger.Default.Register<int>(this, OnLoadedDataPercentageMessageReceived);
        }

        private void OnLoadedDataPercentageMessageReceived(int message)
        {
            LoadedDataLevel = message;
            if (message == 100)
            {
                Messenger.Default.Unregister<int>(this, OnLoadedDataPercentageMessageReceived);
            }
        }
    }
}
