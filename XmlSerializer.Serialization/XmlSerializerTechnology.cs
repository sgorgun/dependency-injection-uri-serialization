using System;
using System.Collections.Generic;
using Serialization;
using Microsoft.Extensions.Logging;

namespace XmlSerializer.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using XmlSerializer class.
    /// </summary>
    public class XmlSerializerTechnology : IDataSerializer<Uri>
    {
        private readonly string path;
        private readonly ILogger<XmlSerializerTechnology>? logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializerTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public XmlSerializerTechnology(string? path, ILogger<XmlSerializerTechnology>? logger = default)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Uri));
            using var writer = new StreamWriter(this.path);
            foreach (var uri in source)
            {
                serializer.Serialize(writer, uri);
            }
            
            this.logger?.LogInformation("Serialization completed successfully.");
        }
    }
}
