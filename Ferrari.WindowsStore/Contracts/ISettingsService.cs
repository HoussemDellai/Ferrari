using System;

namespace Ferrari.Contracts
{
	public interface ISettingsService
	{

		bool RegisterOrUpdateSetting(String settingKey, object settingValue);

		object GetSettingOrDefault(String settingKey);
	}
}
