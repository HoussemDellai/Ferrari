using System.Threading.Tasks;
using Ferrari.Contracts;

namespace Ferrari.Services
{
    public class ContactsService : IContactsService
    {
        public Task<bool> LaunchWebsiteAsync(string url)
        {
            return null;
        }

        public Task<bool> SendEmailAsync(string mailAddress)
        {
            return null;
        }

        public Task<bool> ReviewApplicationOnTheStore()
        {
            return null;
        }

        //public void OpenApplicationPageOnTheStore()
        //{
            
        //}
    }
}
