using System;
using System.Collections.Generic;
using Conversion;
using DataReceiving;
using InMemoryReceiver;
using JsonSerializer.Serialization;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serialization;
using TextFileReceiver;
using UriConversion;
using Validation;
using XDomWriter.Serialization;
using XmlDomWriter.Serialization;
using XmlSerializer.Serialization;
using XmlWriter.Serialization;

namespace ExportDataService.Tests
{
    public class TestCasesData
    {
        const string sourceText = "uri-addresses.txt";
        const string xmlActual = "uri-addresses.xml";
        const string jsonActual = "uri-addresses.json";
        const string xmlExpected = "uri-addresses-result.xml";
        const string jsonExpected = "uri-addresses-result.json";

        public static IEnumerable<TestCaseData> TestCasesForXmlSerializers
        {
            get
            {
                var serviceCollection = new ServiceCollection()
                    .AddTransient<IValidator<string>, UriValidator>()
                    .AddTransient<IConverter<Uri?>, UriConverter>()
                    .AddTransient<ExportDataService<Uri>>();

                yield return new TestCaseData(serviceCollection
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(sourceText))
                    .AddTransient<IDataSerializer<Uri>, XmlSerializerTechnology>(_ =>
                        new XmlSerializerTechnology(xmlActual)), xmlActual, xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(sourceText))
                        .AddTransient<IDataSerializer<Uri>, XDomTechnology>(_ => new XDomTechnology(xmlActual)),
                    xmlActual,
                    xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(sourceText))
                        .AddTransient<IDataSerializer<Uri>, XmlDomTechnology>(_ => new XmlDomTechnology(xmlActual)),
                    xmlActual,
                    xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(sourceText))
                        .AddTransient<IDataSerializer<Uri>, XmlWriterTechnology>(
                            _ => new XmlWriterTechnology(xmlActual)), xmlActual,
                    xmlExpected);
                yield return new TestCaseData(serviceCollection
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, XmlSerializerTechnology>(
                        _ => new XmlSerializerTechnology(xmlActual)), xmlActual, xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                        .AddTransient<IDataSerializer<Uri>, XDomTechnology>(_ => new XDomTechnology(xmlActual)),
                    xmlActual,
                    xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                        .AddTransient<IDataSerializer<Uri>, XmlDomTechnology>(_ => new XmlDomTechnology(xmlActual)),
                    xmlActual,
                    xmlExpected);
                yield return new TestCaseData(serviceCollection
                        .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                        .AddTransient<IDataSerializer<Uri>, XmlWriterTechnology>(
                            _ => new XmlWriterTechnology(xmlActual)), xmlActual,
                    xmlExpected);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForJsonSerializers
        {
            get
            {
                var serviceCollection = new ServiceCollection()
                    .AddTransient<IValidator<string>, UriValidator>()
                    .AddTransient<IConverter<Uri?>, UriConverter>()
                    .AddTransient<ExportDataService<Uri>>();

                yield return new TestCaseData(serviceCollection
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(sourceText))
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(_ =>
                        new JsonSerializerTechnology(jsonActual)), jsonActual, jsonExpected);
                yield return new TestCaseData(serviceCollection
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(_ =>
                        new JsonSerializerTechnology(jsonActual)), jsonActual, jsonExpected);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForUriValidator
        {
            get
            {
                yield return new TestCaseData("https://habrahabr.ru/company/it-grad/blog/341486/", true);
                yield return new TestCaseData("http://www.example.com/customers/12345", true);
                yield return new TestCaseData("http://www.example.com/customers/12345/orders/98765", true);
                yield return new TestCaseData("https://qaevolution.ru/znakomstvo-s-testirovaniem-api/", true);
                yield return new TestCaseData("http://", false);
                yield return new TestCaseData("https://www.contoso.com/Home/Index.htm?q1=v1&q2=v2", true);
                yield return new TestCaseData("http://aaa.com/temp?key=Foo&value=Bar&id=42", true);
                yield return new TestCaseData("https://www.w3schools.com/html/default.asp", true);
                yield return new TestCaseData("http://www.ninject.org/learn.html", true);
                yield return new TestCaseData("https:.php", false);
                yield return new TestCaseData("https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview", true);
                yield return new TestCaseData("docs.microsoft.com", false);
                yield return new TestCaseData("microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/l", false);
                yield return new TestCaseData("https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.queryable.where?view=netframework-4.8", true);
                yield return new TestCaseData("https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=net-6.0", true);
                yield return new TestCaseData("https://metanit.com/python/django/1.1.php", true);
            }
        }
    }
}
