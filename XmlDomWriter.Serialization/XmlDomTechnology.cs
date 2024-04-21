using System;
using System.Collections.Generic;
using System.Xml;
using Serialization;
using Microsoft.Extensions.Logging;

namespace XmlDomWriter.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using XML-DOM model.
    /// </summary>
    public class XmlDomTechnology : IDataSerializer<Uri>
    {
        private readonly string path;
        private readonly ILogger<XmlDomTechnology>? logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDomTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public XmlDomTechnology(string? path, ILogger<XmlDomTechnology>? logger = default)
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
            
            var xmlDoc = new XmlDocument();
            var root = xmlDoc.CreateElement("Uris");
            foreach (var uri in source)
            {
                var uriElement = xmlDoc.CreateElement("Uri");
                uriElement.InnerText = uri.ToString();
                root.AppendChild(uriElement);
            }
            
            xmlDoc.AppendChild(root);
            xmlDoc.Save(this.path);
            this.logger?.LogInformation("Serialization completed successfully.");
        }
    }
}
