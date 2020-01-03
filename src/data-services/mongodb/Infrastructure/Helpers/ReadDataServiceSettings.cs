using Microsoft.Extensions.Configuration;

namespace DataServices.MongoDB.Infrastructure.Helpers
{
    public static class ReadDataServiceSettings
    {
        private static IConfigurationSection Section(this ISettingsReader settingsReader)
        {
            return settingsReader.ConfigurationRoot.GetSection("DatabaseInformation");
        }

        private static string ReadKey(this ISettingsReader settingsReader, string key)
        {
            return Section(settingsReader)[key];
        }

        public static string ReadDatabaseName(this ISettingsReader settingsReader)
        {
            return ReadKey(settingsReader, "Name");
        }

        public static string ReadCollectionName(this ISettingsReader settingsReader, string keyNameCollection)
        {
            return ReadKey(settingsReader, keyNameCollection);
        }

        public static string ReadDBMSAddress(this ISettingsReader settingsReader)
        {
            return ReadKey(settingsReader, "DBMSAddress");
        }
    }
}