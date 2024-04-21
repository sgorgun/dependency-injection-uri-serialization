using System;
using System.Collections.Generic;
using System.Xml;
using Serialization;
using Microsoft.Extensions.Logging;
using UriSerializer;

namespace XmlWriter.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using XmlWriter class.
    /// </summary>
    public class XmlWriterTechnology : IDataSerializer<Uri>
    {
        private readonly string path;
        private readonly ILogger<XmlWriterTechnology>? logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriterTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public XmlWriterTechnology(string? path, ILogger<XmlWriterTechnology>? logger = default)
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
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using var writer = System.Xml.XmlWriter.Create(this.path, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("uriAdresses");

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var item in source.Where(uri => uri is not null).Select(uri => uri.ToSerializableObject()))
            {
                writer.WriteStartElement("uriAdress");

                writer.WriteStartElement("scheme");
                writer.WriteAttributeString("name", item.scheme);
                writer.WriteEndElement();

                writer.WriteStartElement("host");
                writer.WriteAttributeString("name", item.host);
                writer.WriteEndElement();

                writer.WriteStartElement("path");
                foreach (var segment in item.path)
                {
                    writer.WriteElementString("segment", segment);
                }

                writer.WriteEndElement();

                if (item.query.Count > 0)
                {
                    writer.WriteStartElement("query");
                    foreach (var parameter in item.query)
                    {
                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("key", parameter.key);
                        writer.WriteAttributeString("value", parameter.value);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            this.logger?.LogInformation("Source has been serialized to the specified path {Path} using XmlWriter", this.path);
        }
    }
}
