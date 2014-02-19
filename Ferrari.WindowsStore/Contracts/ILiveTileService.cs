using System;

namespace Ferrari.Contracts
{
	public interface ILiveTileService
	{
		void TryUpdateLiveTileAsync(String liveTileText, string imageUrl);
	}
}
