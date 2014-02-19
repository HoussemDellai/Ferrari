﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Notifications;

namespace Ferrari.External.Notification
{
	class Program
	{
		static void Main(string[] args)
		{
			SendNotificationAsync();

			Console.ReadLine();
		}

		private static async void SendNotificationAsync()
		{
			var hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://ferrarifans.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=bAOFD6ohHBLv3VPmOEuc0ZzRKukLsbcjx0p//WRMSXo=", "ferrarimagazine");

			var tile = @"<?xml version=""1.0"" encoding=""utf-8""?>
						<tile>
						<visual><binding template=""TileSquareText04"">
						<text id=""1"">Hello from a .NET App!</text>
						</binding>
						</visual>
						</tile>";

			var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">Hello from a .NET App!</text></binding></visual></toast>";

			await hub.SendWindowsNativeNotificationAsync(toast);

			await hub.SendWindowsNativeNotificationAsync(tile);
		}
	}
}
