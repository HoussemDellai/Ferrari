
using System;
using Windows.ApplicationModel.DataTransfer;
using Ferrari.Contracts;

namespace Ferrari.WindowsStore.Services
{
	public class SharingService : ISharingService
	{

		private DataPackage _requestData;

		private string _title = string.Empty;
		private string _description = string.Empty;
		private string _imageUrl = string.Empty;

		private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
		{
			_requestData = e.Request.Data;

			_requestData.Properties.Title = _title;
			_requestData.Properties.Description = _description;
			_requestData.SetWebLink(new Uri(_imageUrl));
		}

		public void RegisterForShare(string title, string description, string imageUrl)
		{
			_title = title;
			_description = description;
			_imageUrl = imageUrl;

			var dataTransferManager = DataTransferManager.GetForCurrentView();
			if (dataTransferManager == null) return;
			dataTransferManager.DataRequested += OnDataRequested;
		}

		public void ShowShareUi()
		{
			DataTransferManager.ShowShareUI();
		}
	}
}
