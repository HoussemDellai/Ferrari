using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Ferrari.Contracts;
using Ferrari.WindowsStore.Contracts;

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
			try
			{
				TileUpdateManager.CreateTileUpdaterForApplication()
								 .EnableNotificationQueue(true);

				var liveTileXml = @"<tile>
									  <visual version=""2"">
									    <binding template=""TileSquare310x310ImageAndTextOverlay01"">
									      <image id=""1"" src=""" + imageUrl + @""" alt=""alt text""/>
									      <text id=""1"">" + liveTileText + @"</text>
									    </binding>  
									  </visual>
									</tile>";

				var wideLiveTileXml = @"<tile>
										  <visual version=""2"">
										    <binding template=""TileWide310x150PeekImage03"" fallback=""TileWidePeekImage03"">
										      <image id=""1"" src=""" + imageUrl + @""" alt=""alt text""/>
										      <text id=""1"">" + liveTileText + @"</text>
										    </binding>  
										  </visual>
										</tile>";

				var squareLiveTileXml = @"<tile>
										   <visual version=""2"">
										     <binding template=""TileSquare150x150PeekImageAndText04"" fallback=""TileSquarePeekImageAndText04"">
										       <image id=""1"" src=""" + imageUrl + @""" alt=""alt text""/>
										       <text id=""1"">" + liveTileText + @"</text>
										     </binding>  
										   </visual>
										 </tile>";

				var tileXml = new XmlDocument();
			
				tileXml.LoadXml(liveTileXml);
				var tileNotification = new TileNotification(tileXml);
				TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

				tileXml.LoadXml(wideLiveTileXml);
				var wideTileNotification = new TileNotification(tileXml);
				TileUpdateManager.CreateTileUpdaterForApplication().Update(wideTileNotification);

				tileXml.LoadXml(squareLiveTileXml);
				var squareTileNotification = new TileNotification(tileXml);
				TileUpdateManager.CreateTileUpdaterForApplication().Update(squareTileNotification);

				TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(new ScheduledTileNotification(tileXml, new DateTimeOffset(0, 0,0,0,0,30,0, new TimeSpan(0,0,30))));
			}
			catch
			{
				// do nothing, it doesn't matter!
			}
		}
	}
}
