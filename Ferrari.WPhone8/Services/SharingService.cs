using System;
using Ferrari.Contracts;
using Microsoft.Phone.Tasks;

namespace Ferrari.WindowsStore.Services
{
	public class SharingService : ISharingService
	{

	    private string _title;
	    private string _description;
	    private string _imageUrl;

	    public void RegisterForShare(
            string title,
	        string description,
	        string imageUrl)
	    {
            _imageUrl = imageUrl;
            _description = description;
            _title = title;
	    }

	    public void ShowShareUi()
	    {
            var task = new ShareLinkTask
            {
                Title = _title,
                LinkUri = new Uri(_imageUrl),
                Message = _description
            };

            task.Show();
	    }
	}
}
