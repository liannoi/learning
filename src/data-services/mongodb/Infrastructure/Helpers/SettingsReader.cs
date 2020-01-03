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