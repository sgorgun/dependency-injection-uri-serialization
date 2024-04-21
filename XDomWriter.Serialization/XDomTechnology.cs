using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Serialization;
using Microsoft.Extensions.Logging;
using UriSerializer;

namespace XDomWriter.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using X-DOM model.
    /// </summary>
    public class XDomTechnology : IDataSerializer<Uri>
    {
        private readonly string path;
        private readonly ILogger<XDomTechnology>? logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="XDomTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public XDomTechnology(string? path, ILogger<XDomTechnology>? logger = default)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "The provided path cannot be null or empty.");
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

            List<XElement> uriAdresses = new List<XElement>();
            foreach (Uri uri in source)
            {
                if (uri != null)
                {
                    var obj = uri.ToSerializableObject();

                    XElement uriAddress = new XElement("uriAdress",
                        new XElement("scheme", new XAttribute("name", obj.scheme)),
                        new XElement("host", new XAttribute("name", obj.host)),
                        new XElement("path", obj.path.Select(seg => new XElement("segment", seg))));

                    if (obj.query.Count > 0)
                    {
                        XElement query = new XElement("query");
                        foreach (var q in obj.query)
                        {
                            XElement parameter = new XElement("parameter",
                                new XAttribute("key", q.key),
                                new XAttribute("value", q.value));
                            query.Add(parameter);
                        }

                        uriAddress.Add(query);
                    }

                    uriAdresses.Add(uriAddress);
                }
            }

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using XmlWriter xmlWriter = XmlWriter.Create(this.path, settings);
            XDocument xdoc = new XDocument(new XElement("uriAdresses", uriAdresses));
            xdoc.Save(xmlWriter);
            xmlWriter.Close();

            this.logger?.LogInformation("Source has been serialized to the specified path {Path} using XDom", this.path);
        }
    }
}
