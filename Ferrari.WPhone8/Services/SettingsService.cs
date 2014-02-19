using System;
using Ferrari.Contracts;

namespace Ferrari.WindowsStore.Services
{
	public class SettingsService : ISettingsService
	{
	    public bool RegisterOrUpdateSetting(string settingKey,
	        object settingValue)
	    {
	        throw new NotImplementedException();
	    }

	    public object GetSettingOrDefault(string settingKey)
	    {
	        throw new NotImplementedException();
	    }
	}
}
