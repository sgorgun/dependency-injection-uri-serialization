using System;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace UriSerializer
{
    [XmlRoot(ElementName = "uriAdresses")]
    public class UriAddressContainer
    {
        public UriAddressContainer()
        {
        }

        public UriAddressContainer(IEnumerable<UriAddresses> source)
        {
            this.UriAddresses = source.ToArray();
        }

        [XmlElement("uriAdress")]
        public UriAddresses[] UriAddresses { get; set; } = null!;
    }

    [XmlRoot("uriAdresses")]
    public class UriAddresses
    {
        [XmlIgnore]
        public string scheme
        {
            get => attrScheme.name;
            set => attrScheme.name = value;
        }

        [XmlIgnore]
        public string host
        {
            get => attrHost.name;
            set => attrHost.name = value;
        }

        [XmlElement("scheme")]
        public InnerNamed attrScheme = new();

        [XmlElement("host")]
        public InnerNamed attrHost = new();

        [XmlArrayItem("segment")]
        public List<string> path { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public List<QueryParameter> query { get; set; }

        [JsonPropertyName("query")]
        [XmlArray("query")]
        [XmlArrayItem("parameter")]
        public List<QueryParameter>? querySerializable { get => query.Count > 0 ? query : null; }

        public struct InnerNamed
        {
            [XmlAttribute("name")]
            public string name { get; set; }
        }
    }

    public class QueryParameter
    {
        [XmlAttribute("key")]
        public string key { get; set; }

        [XmlAttribute("value")]
        public string value { get; set; }
    }
}
