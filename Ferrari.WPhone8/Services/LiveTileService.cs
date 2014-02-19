using System;
using System.Linq;
using Ferrari.Contracts;
using Microsoft.Phone.Shell;

namespace Ferrari.WindowsStore.Services
{
	/// <summary>
	/// http://msdn.microsoft.com/library/windows/apps/windows.ui.notifications.tiletemplatetype
	/// http://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx
	/// </summary>
	public class LiveTileService : ILiveTileService
	{
		public void TryUpdateLiveTileAsync(String liveTileText, string imageUrl)
		{
            var primaryTileData = new FlipTileData
            {
                Title = "Ferrari Magazine",
                BackTitle = "Ferrari Magazine",
                WideBackContent = liveTileText,
               // Count = count,
                BackContent = liveTileText,
                BackgroundImage = new Uri(imageUrl),
                WideBackgroundImage = new Uri(imageUrl),
            };

            var primaryTile = ShellTile.ActiveTiles.First();
            primaryTile.Update(primaryTileData);
		}
	}
}
