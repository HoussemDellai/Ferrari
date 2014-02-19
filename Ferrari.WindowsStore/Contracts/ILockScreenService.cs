namespace Ferrari.Contracts
{
   public interface ILockScreenService
   {

       void TrySetImageAsLockScreenBackground(string imageUrl);
   }
}
