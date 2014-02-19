using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Ferrari.Contracts;
using Ferrari.Models;
using Ferrari.Utilities;
using Microsoft.Practices.Unity;

namespace Ferrari.ViewModels
{
	/// <summary>
	/// Base class for view models that provides common funtionalities. 
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
	{
		private readonly ISharingService _sharingService;
		private readonly IPageNavigationService _pageNavigationService;
	    private readonly IUnityContainer _unityContainer;
	    private RelayCommand _shareItemCommand;
		private RelayCommand _navigateToBackPageCommand;
        private RelayCommand _navigateToMainPageCommand;
	    private ICommand _navigateToAboutUsPageCommand;
        //private ICommand _navigateToVideoPlayerPageCommand;

	    public RelayCommand ShareItemCommand
		{
			get
			{
				if (_shareItemCommand == null)
				{
					_shareItemCommand = new RelayCommand(_sharingService.ShowShareUi);
				}
				return _shareItemCommand;
			}
		}

		/// <summary>
		/// This command will navigate back, 
		/// </summary>
		public RelayCommand NavigateToBackPageCommand
		{
			get
			{
				if (_navigateToBackPageCommand == null)
				{
					_navigateToBackPageCommand = new RelayCommand(() => _pageNavigationService.GoBack()); 
				}
				return _navigateToBackPageCommand;
			}
		}

        public RelayCommand NavigateToMainPageCommand
        {
            get
            {
                if (_navigateToMainPageCommand == null)
                {
                    _navigateToMainPageCommand = new RelayCommand(() => _pageNavigationService.NavigateToMainPage());
                }
                return _navigateToMainPageCommand;
            }
        }

	    public ICommand NavigateToAboutUsPageCommand
	    {
	        get
	        {
                if (_navigateToAboutUsPageCommand == null)
                {
                    _navigateToAboutUsPageCommand = new RelayCommand(() => _pageNavigationService.NavigateToAboutUsPage());
                }
	            return _navigateToAboutUsPageCommand;
	        }
	    }

        //public bool IsTopAppBarVisible
        //{
        //    get
        //    {
        //        return _isTopAppBarVisible;
        //    }
        //    set
        //    {
        //        _isTopAppBarVisible = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ICommand ShowTopAppBarCommand
        //{
        //    get
        //    {
        //        if (_showTopAppBarCommand == null)
        //        {
        //            _showTopAppBarCommand = new RelayCommand(() => IsTopAppBarVisible = true);
        //        }
        //        return _showTopAppBarCommand;
        //    }
        //}

	    //public ICommand NavigateToVideoPlayerPageCommand
	    //{
	    //    get
	    //    {
	    //        if (_navigateToVideoPlayerPageCommand == null)
	    //        {
	    //            _navigateToVideoPlayerPageCommand = new RelayCommandGeneric<YoutubeVideo>(video =>
	    //            {
	    //                _unityContainer.RegisterInstance(video);
	    //                _unityContainer.RegisterInstance()
	    //                _pageNavigationService.NavigateToVideoPlayerPage();
	    //            });
	    //        }
	    //        return _navigateToVideoPlayerPageCommand;
	    //    }
	    //}

	    public BaseViewModel()
	    {
	        
	    }

		public BaseViewModel(ISharingService sharingService,
		    IPageNavigationService pageNavigationService,
		    IUnityContainer unityContainer)
		{
			_sharingService = sharingService;
			_pageNavigationService = pageNavigationService;
		    _unityContainer = unityContainer;
		}

		public event PropertyChangedEventHandler PropertyChanged;
        //private bool _isTopAppBarVisible;
        //private ICommand _showTopAppBarCommand;

	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
