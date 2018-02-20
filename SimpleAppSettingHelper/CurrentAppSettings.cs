using System;
using System.ComponentModel;
using System.Configuration;

namespace SimpleAppSettingHelper
{
	/// <summary>
	/// Gets values from the current app.config.  Works for both web and console applications.
	/// </summary>
	public static class CurrentAppSettings
	{
		private static string GetCurrentlyRunningApplicationConfig()
		{
			var configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			return configFile;
		}

		/// <summary>
		/// Get an app setting or the default value
		/// </summary>
		/// <param name="keyName"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string Get(string keyName, string defaultValue)
		{
			return Get(GetCurrentlyRunningApplicationConfig(), keyName, false, defaultValue);
		}

		/// <summary>
		/// Central method for attempting to get an app.setting value.
		/// </summary>
		/// <param name="keyName">The key name you want to find the value for</param>
		/// <param name="ifValueIsNullOrEmptyThrowArgumentException">If the value is null or empty should an application exception be thrown</param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string Get(string keyName, bool ifValueIsNullOrEmptyThrowArgumentException = true, string defaultValue = "")
		{
			return Get(GetCurrentlyRunningApplicationConfig(), keyName, ifValueIsNullOrEmptyThrowArgumentException, defaultValue);
		}

		/// <summary>
		/// Get an app setting with a specific return type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="keyName"></param>
		/// <param name="ifValueIsNullOrEmptyThrowArgumentException"></param>
		/// <returns></returns>
		public static T Get<T>(string keyName, bool ifValueIsNullOrEmptyThrowArgumentException = true)
		{
			object value = Get(GetCurrentlyRunningApplicationConfig(), keyName, ifValueIsNullOrEmptyThrowArgumentException, String.Empty);

            //If the type isn't a string return default of desired type

            if ((string)value == String.Empty)
            {
                return default(T);
            }

            if (typeof(Guid) == typeof(T))
			{
                
				//Be careful with using ConvertFromInvariantString. If your type is a DateTime and you have international date formats, this will blow up.
				return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(value.ToString());
			}

            return (T)Convert.ChangeType(value, typeof(T));
		}


		public static T GetEnum<T>(string keyName, T defaultEnum) where T : struct
		{
			object value = Get(GetCurrentlyRunningApplicationConfig(), keyName, false, defaultEnum.ToString());
			return EnumToString<T>(value.ToString());
		}

		public static T GetEnum<T>(string keyName, bool ifValueIsNullOrEmptyThrowArgumentException = true) where T : struct
		{
			object value = Get(GetCurrentlyRunningApplicationConfig(), keyName, ifValueIsNullOrEmptyThrowArgumentException, String.Empty);
			return EnumToString<T>(value.ToString());

		}

		private static T EnumToString<T>(string value) where T : struct
		{
			try
			{

				T res = (T)Enum.Parse(typeof(T), value);
				if (!Enum.IsDefined(typeof(T), res)) return default(T);
				return res;
			}
			catch
			{
				return default(T);
			}
		}

		/// <summary>
		/// Central method for attempting to get an app.setting value.
		/// </summary>
		/// <param name="configFile"></param>
		/// <param name="keyName">The key name you want to find the value for</param>
		/// <param name="ifValueIsNullOrEmptyThrowArgumentException">If the value is null or empty should an application exception be thrown</param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string Get(string configFile, string keyName,
			bool ifValueIsNullOrEmptyThrowArgumentException = true, string defaultValue = "")
		{
			var result = string.Empty;
			var configFileMap = new ExeConfigurationFileMap();
			configFileMap.ExeConfigFilename = configFile;
			var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
			if (config.AppSettings.Settings[keyName] != null)
			{
				result = config.AppSettings.Settings[keyName].Value;
			}

			if (ifValueIsNullOrEmptyThrowArgumentException && string.IsNullOrWhiteSpace(result))
			{
				throw new ArgumentException(string.Format("Unable to find required application setting key named '{0}'.", keyName));
			}

			if (defaultValue != string.Empty && string.IsNullOrWhiteSpace(result))
			{
				return defaultValue;
			}

			return result;
		}

	}
}
