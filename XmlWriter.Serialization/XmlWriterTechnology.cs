using System;
using System.Collections.Generic;
using System.Xml;
using Serialization;
using Microsoft.Extensions.Logging;

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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(this.path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Uris");
                foreach (var uri in source)
                {
                    writer.WriteStartElement("Uri");
                    writer.WriteString(uri.ToString());
                    writer.WriteEndElement();
                }
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            
            this.logger?.LogInformation("Serialization completed successfully.");
        }
    }
}
