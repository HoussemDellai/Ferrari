using System;
using Windows.Foundation;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;
using Ferrari.ViewModels;
using Ferrari.WindowsStore.SettingsFlyouts;
using Ferrari.WindowsStore.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.WindowsAzure.Messaging;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Networking.PushNotifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Ferrari.WindowsStore
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App
	{

		  private const double SettingsWidth = 370;
        Popup _settingsPopup;

		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			InitializeComponent();
			Suspending += OnSuspending;
		}

		/// <summary>
		/// http://www.windowsazure.com/en-us/documentation/articles/notification-hubs-windows-store-dotnet-get-started/
		/// </summary>
		private async void InitNotificationsAsync()
		{
			try
			{
				var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

				var hub = new NotificationHub("ferrarimagazine", "Endpoint=sb://ferrarifans.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=Y2GhUIPcgEh/uIpv10H2ImF7/p+fkkWYskS8GoUdBV0=");

				await hub.RegisterNativeAsync(channel.Uri);

				//// Displays the registration ID so you know it was successful
				//if (result.RegistrationId != null)
				//{
				//	var dialog = new MessageDialog("Registration successful: " + result.RegistrationId);
				//	dialog.Commands.Add(new UICommand("OK"));
				//	await dialog.ShowAsync();
				//}
			}
			catch (Exception)
			{
				// skip..				
			}
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override async void OnLaunched(LaunchActivatedEventArgs e)
		{

			InitNotificationsAsync();

#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				this.DebugSettings.EnableFrameRateCounter = true;
			}
#endif

			Frame rootFrame = Window.Current.Content as Frame;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();
				// Set the default language
				rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{

				// When the navigation stack isn't restored navigate to the first page,
				// configuring the new page by passing required information as a navigation
				// parameter
				if (!rootFrame.Navigate(typeof(SplashScreenPage)))
				{
					throw new Exception("Failed to create initial page");
				}

				Window.Current.Activate();

				await ServiceLocator.Current.GetInstance<MainPageViewModel>().StartInitializeDataAsync();

				rootFrame.Navigate(typeof(MainPage), e.Arguments);
			}
			// Ensure the current window is active
			Window.Current.Activate();
		}

		protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += App_CommandsRequested;
        }

        void App_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            UICommandInvokedHandler handler = OnSettingsCommand;

			//var appSettingCommand = new SettingsCommand("AS", "Options", handler);
            var aboutCommand = new SettingsCommand("AU", "About Us", handler);
            var privacySettingCommand = new SettingsCommand("PS", "Privacy settings", handler);

			//args.Request.ApplicationCommands.Add(appSettingCommand);
            args.Request.ApplicationCommands.Add(aboutCommand);
            args.Request.ApplicationCommands.Add(privacySettingCommand);
        }

        private void OnSettingsCommand(IUICommand command)
        {
            Rect windowBounds = Window.Current.Bounds;
            _settingsPopup = new Popup();
            _settingsPopup.Closed += SettingsPopup_Closed;
            Window.Current.Activated += Current_Activated;
            _settingsPopup.IsLightDismissEnabled = true;
			SettingsFlyout settingPage = null;

            switch (command.Id.ToString())
            {
                case "AU":
                    settingPage = new AboutUsFlyout();
                    break;
                case "PS":
					Launcher.LaunchUriAsync(new Uri("http://houssemdellai-services.azurewebsites.net/FerrariMagazine/Index"));
                    break;
				//case "AS":
				//	settingPage = new AppSettings();
				//	break;
            }
            _settingsPopup.Width = SettingsWidth;
            _settingsPopup.Height = windowBounds.Height;

            // Add the proper animation for the panel.
            _settingsPopup.ChildTransitions = new TransitionCollection
                {
                    new PaneThemeTransition
                        {
                            Edge = (SettingsPane.Edge == SettingsEdgeLocation.Right)
                                       ? EdgeTransitionLocation.Right
                                       : EdgeTransitionLocation.Left
                        }
                };
            if (settingPage != null)
            {
                settingPage.Width = SettingsWidth;
                settingPage.Height = windowBounds.Height;
            }

            // Place the SettingsFlyout inside our Popup window.
            _settingsPopup.Child = settingPage;

            // Let's define the location of our Popup.
            _settingsPopup.SetValue(Canvas.LeftProperty, SettingsPane.Edge == SettingsEdgeLocation.Right ? (windowBounds.Width - SettingsWidth) : 0);
            _settingsPopup.SetValue(Canvas.TopProperty, 0);
            _settingsPopup.IsOpen = true;
        }

        void Current_Activated(object sender, WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                _settingsPopup.IsOpen = false;
            }
        }

        void SettingsPopup_Closed(object sender, object e)
        {
            Window.Current.Activated -= Current_Activated;
        }

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}
