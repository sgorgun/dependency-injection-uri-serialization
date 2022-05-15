using System;
using System.IO;
using DataReceiving;
using InMemoryReceiver;
using JsonSerializer.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serialization;
using TextFileReceiver;
using XDomWriter.Serialization;
using XmlSerializer.Serialization;

namespace ConsoleClient
{
    /// <summary>
    /// Extension methods for service collection.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add northwind services to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        public static IServiceCollection UseExportDataServices(this IServiceCollection services, IConfiguration configuration, string format, string mode)
        {
            string path = Directory.GetCurrentDirectory();

            string txtPath = Path.Combine(path, configuration["textFilePath"]) ??
                             throw new ArgumentNullException("textFilePath");
            string xmlPath = Path.Combine(path, configuration["xmlFilePath"]) ??
                             throw new ArgumentNullException("xmlFilePath");
            string jsonPath = Path.Combine(path, configuration["jsonFilePath"]) ??
                              throw new ArgumentNullException("jsonFilePath");

            return format switch
            {
                "xml" when mode == "inFile" => services
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(txtPath))
                    .AddTransient<IDataSerializer<Uri>, XDomTechnology>(_ => new XDomTechnology(xmlPath))
                    .AddTransient<IDataSerializer<Uri>, XmlSerializerTechnology>(_ => new XmlSerializerTechnology(xmlPath)),
                "xml" when mode == "inMemory" => services
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, XDomTechnology>(_ => new XDomTechnology(xmlPath)),
                "json" when mode == "inFile" => services
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(txtPath))
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(_ => new JsonSerializerTechnology(jsonPath)),
                "json" when mode == "inMemory" => services
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(_ => new JsonSerializerTechnology(jsonPath)),
                _ => throw new ArgumentException(nameof(format), format, null)
            };
        }
    }
}
