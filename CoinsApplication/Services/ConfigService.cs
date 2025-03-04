using Microsoft.Extensions.Configuration;
using System;
using System.IO;

public class ConfigService
{
    public static IConfigurationRoot LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder.Build();
    }
}