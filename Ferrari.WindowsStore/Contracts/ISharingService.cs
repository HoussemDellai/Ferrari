namespace Ferrari.Contracts
{
	public interface ISharingService
	{

		//void ShareContent(string title, string description, string uriString);

		void RegisterForShare(string title, string description, string imageUrl);

		void ShowShareUi();
	}
}
