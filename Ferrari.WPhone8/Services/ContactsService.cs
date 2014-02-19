using System;
using System.Threading.Tasks;
using Windows.System;
using Ferrari.Contracts;
using Microsoft.Phone.Tasks;

namespace Ferrari.Services
{
    public class ContactsService : IContactsService
    {

        public async Task<bool> LaunchWebsiteAsync(string url)
        {
            return await Launcher.LaunchUriAsync(new Uri(url));
        }

        public Task<bool> SendEmailAsync(string mailAddress)
        {
            var emailComposeTask = new EmailComposeTask
            {
                Subject = "About Ferrari Magazine",
                Body = "Hi Houssem, ...",
                To = mailAddress,
                //Cc = "cc@example.com",
                //Bcc = "bcc@example.com"
            };

            emailComposeTask.Show();

            return Task.FromResult(true);
        }


        public Task<bool> ReviewApplicationOnTheStore()
        {
            var marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();

            return Task.FromResult(true);
        }


        //public void OpenApplicationPageOnTheStore()
        //{
        //    var marketplaceReviewTask = new MarketplaceReviewTask();

        //    marketplaceReviewTask.Show();
        //}
    }
}
