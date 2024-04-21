using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Serialization;

namespace JsonSerializer.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using JsonSerialization class.
    /// </summary>
    public class JsonSerializerTechnology : IDataSerializer<Uri>
    {
        private readonly string path;
        private readonly ILogger<JsonSerializerTechnology>? logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public JsonSerializerTechnology(string? path, ILogger<JsonSerializerTechnology>? logger = default)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }
            
            this.path = path;
            this.logger = logger;
        }

        /// <summary>
        /// Serializes the source sequence of Uri elements in json format. 
        /// </summary>
        /// <param name="source">The source sequence of Uri elements.</param>
        /// <exception cref="ArgumentNullException">Throw if the source sequence is null.</exception>
        public void Serialize(IEnumerable<Uri>? source)
        {
            var result = (source ?? throw new ArgumentNullException(nameof(source))).Where(uri => true)
                .Select(uri => uri.ToString());

            using var fileStream = File.Create(this.path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            System.Text.Json.JsonSerializer.Serialize(fileStream, result, options);
            this.logger?.LogInformation("source serialized to {Path} using Json", this.path);
        }
    }
}
