using System;
using Ferrari.Contracts;
using Windows.Storage;

namespace Ferrari.WindowsStore.Services
{
	public class SettingsService : ISettingsService
	{
		public bool RegisterOrUpdateSetting(string settingKey, object settingValue)
		{
			try
			{
				ApplicationData.Current.LocalSettings.Values[settingKey] = settingValue;

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public object GetSettingOrDefault(string settingKey)
		{
			var result = ApplicationData.Current.LocalSettings.Values[settingKey];

			return result;
		}
	}
}
