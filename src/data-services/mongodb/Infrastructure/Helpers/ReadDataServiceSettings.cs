// Copyright 2020 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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