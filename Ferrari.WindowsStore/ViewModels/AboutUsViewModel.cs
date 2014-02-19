using System.Windows.Input;
using Ferrari.Contracts;
using Ferrari.Utilities;

namespace Ferrari.ViewModels
{
    public class AboutUsViewModel
    {
        private readonly IContactsService _contactsService;
        private ICommand _sendEmailCommand;
        private ICommand _launchWebsiteCommand;
        private ICommand _launchTwitterWebsiteCommand;
        private ICommand _rateAndReviewApplicationOnTheStoreCommand;

        public ICommand SendEmailCommand
        {
            get
            {
                if (_sendEmailCommand == null)
                {
                    _sendEmailCommand = new RelayCommand(() => _contactsService.SendEmailAsync("houssem.dellai@live.com"));
                }
                return _sendEmailCommand;
            }
        }

        public ICommand LanuchWebsiteCommand
        {
            get
            {
                if (_launchWebsiteCommand == null)
                {
                    _launchWebsiteCommand = new RelayCommand(() => _contactsService.LaunchWebsiteAsync("http://houssemdellai.net"));
                }
                return _launchWebsiteCommand;
            }
        }

        public ICommand LaunchTwitterWebsiteCommand
        {
            get
            {
                if (_launchTwitterWebsiteCommand == null)
                {
                    _launchTwitterWebsiteCommand = new RelayCommand(() => _contactsService.LaunchWebsiteAsync("https://twitter.com/HoussemDellai"));
                }
                return _launchTwitterWebsiteCommand;
            }
        }

        public ICommand RateAndReviewApplicationOnTheStoreCommand
        {
            get
            {
                if (_rateAndReviewApplicationOnTheStoreCommand == null)
                {
                    _rateAndReviewApplicationOnTheStoreCommand = new RelayCommand(() => _contactsService.ReviewApplicationOnTheStore());
                }
                return _rateAndReviewApplicationOnTheStoreCommand;
            }
        }

        public AboutUsViewModel(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
    }
}
