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

using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataServices.MongoDB.Infrastructure.Helpers
{
    public class SettingsReader : ISettingsReader
    {
        private readonly IConfigurationBuilder _configurationBuilder;

        public SettingsReader(IConfigurationBuilder configurationBuilder)
        {
            _configurationBuilder = configurationBuilder;
            Build();
        }

        public SettingsReader(string fileName)
        {
            _configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName, true, true);
            Build();
        }

        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public void Build()
        {
            ConfigurationRoot = _configurationBuilder.Build();
        }
    }
}