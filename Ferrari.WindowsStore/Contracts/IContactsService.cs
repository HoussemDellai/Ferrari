using System.Threading.Tasks;

namespace Ferrari.Contracts
{
    public interface IContactsService
    {

        Task<bool> LaunchWebsiteAsync(string url);

        Task<bool> SendEmailAsync(string mailAddress);

        Task<bool> ReviewApplicationOnTheStore();

        //void OpenApplicationPageOnTheStore();
    }
}
