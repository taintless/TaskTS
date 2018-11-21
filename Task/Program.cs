using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            var configuration = builder.Build();

            var readFromPath = configuration.GetSection("ReadFromPath").Value;

            var writeToPath = configuration.GetSection("WriteToPath").Value;

            var fileData = Services.ReadFromFile(readFromPath);

            var finalText = Services.FormatWrappedString(new FileInfoModel
            {
                Text = fileData[0],
                SymbolsCount = Services.StringToCount(fileData[1])
            });

            Services.WriteToFile(writeToPath, finalText);
        }
    }
}
