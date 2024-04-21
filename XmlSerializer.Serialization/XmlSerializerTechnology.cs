using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using Serialization;
using Microsoft.Extensions.Logging;
using UriSerializer;

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
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var result = source.Where(uri => uri is not null).Select(uri => uri.ToSerializableObject());
            var addressContainer = new UriAddressContainer(result);

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(UriAddressContainer));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var settings = new XmlWriterSettings { Indent = true };
            using var writer = XmlWriter.Create(this.path, settings);
            serializer.Serialize(writer, addressContainer, namespaces);
            this.logger?.LogInformation("Source has been serialized to the specified path {Path} using XmlSerializer", this.path);
        }
    }
}
