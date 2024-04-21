using System;
using System.Collections.Generic;
using System.Xml;
using Serialization;
using Microsoft.Extensions.Logging;
using UriSerializer;

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
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("uriAdresses");
            document.AppendChild(root);

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var item in source)
            {
                if (item is null)
                {
                    continue;
                }

                var serializableObject = item.ToSerializableObject();

                XmlElement address = document.CreateElement("uriAdress");
                root.AppendChild(address);

                XmlElement scheme = document.CreateElement("scheme");
                scheme.SetAttribute("name", serializableObject.scheme);
                address.AppendChild(scheme);

                XmlElement host = document.CreateElement("host");
                host.SetAttribute("name", serializableObject.host);
                address.AppendChild(host);

                XmlElement xmlPath = document.CreateElement("path");
                foreach (var seg in serializableObject.path)
                {
                    XmlElement segment = document.CreateElement("segment");
                    XmlText text = document.CreateTextNode(seg);
                    segment.AppendChild(text);
                    xmlPath.AppendChild(segment);
                }

                address.AppendChild(xmlPath);

                if (serializableObject.query.Count > 0)
                {
                    XmlElement query = document.CreateElement("query");
                    foreach (var par in serializableObject.query)
                    {
                        XmlElement parameter = document.CreateElement("parameter");
                        parameter.SetAttribute("key", par.key);
                        parameter.SetAttribute("value", par.value);
                        query.AppendChild(parameter);
                    }

                    address.AppendChild(query);
                }
            }

            document.Save(this.path);
            this.logger?.LogInformation("Source has been serialized to the specified path {Path} using XmlDom", this.path);
        }
    }
}
