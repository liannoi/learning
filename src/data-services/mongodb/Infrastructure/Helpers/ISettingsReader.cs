using Microsoft.Extensions.Configuration;

namespace DataServices.MongoDB.Infrastructure.Helpers
{
    public interface ISettingsReader
    {
        IConfigurationRoot ConfigurationRoot { get; }
        void Build();
    }
}