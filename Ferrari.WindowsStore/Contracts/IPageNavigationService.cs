namespace Ferrari.Contracts
{
	public interface IPageNavigationService
	{

		void GoBack();

		void NavigateToItemDetailPage();

		void NavigateToMainPage();

	    void NavigateToVideoPlayerPage();

	    void NavigateToVideosCollectionPage();

		void NavigateToAlbumPhotosPage();

	    void NavigateToAboutUsPage();

		void NavigateToCarSpecificationPage();
	}
}
