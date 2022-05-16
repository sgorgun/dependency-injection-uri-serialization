# Dependency Injection. Uri serialization.

## Task Description

The type system that describe the logic of the export of the string representation of the data to the other format (see [Convertion](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Conversion/IConverter.cs#L7), [Validation](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Validation/IValidator.cs#L7), [Serialization](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Serialization/IDataSerializer.cs#L17), [DataReceiving](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/DataReceiving/IDataReceiver.cs#L8), [ExportDataService](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Conversion/IConverter.cs#L7)) are present in solution.
<details><summary>See scheme.</summary>

  ![](/Images/Architecture1.png)

</details>

Use this types to develop a type system 
  - to reveive as `IEnumerable<string>` data represented as strings that store the information about Uri's in the form `<scheme>://<host>/<path>?<query>`, where   
    - `path` may consist of segments of the form `segment1/segment2/.../segmentN`,
    - `query` consist pairs of the form `key1=value1&...&keyK=valueK`.
  - to convert string object to [Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-6.0) object.
  - to export `IEnumerable<Uri>` to XML and JSON formats.
  
#### Task details.
- In implementation the string receiver functionality consider getting data from both [text](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/TextFileReceiver/TextStreamReceiver.cs#L11) file and [memory](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/InMemoryReceiver/InMemoryDataReceiver.cs#L9).
  <details><summary>See a scheme.</summary>

    ![](/Images/Architecture3.png)

  </details>
  <details>
  <summary>See an example of string data.</summary>

  ```
  https://habrahabr.ru/company/it-grad/blog/341486/
  http://www.example.com/customers/12345
  http://www.example.com/customers/12345/orders/98765
  https://qaevolution.ru/znakomstvo-s-testirovaniem-api/
  http://
  https://www.contoso.com/Home/Index.htm?q1=v1&q2=v2
  http://aaa.com/temp?key=Foo&value=Bar&id=42
  https://www.w3schools.com/html/default.asp
  http://www.ninject.org/learn.html
  https:.php
  https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview
  docs.microsoft.com
  microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/l
  https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.queryable.where?view=netframework-4.8
  https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=net-6.0
  https://metanit.com/python/django/1.1.php
  ```
  </details>

- In implementation the serialization logic consider following .NET technologies:
  - XmlWrite class
  - XmlSerializer class
  - XML-DOM model
  - X-DOM model
  - JsonSerializer.

  <details><summary>See a scheme.</summary>

    ![](/Images/Architecture2.png)

  </details>

  <details>
  <summary>See an example of XML format.</summary>

  ```
  <?xml version="1.0" encoding="utf-8"?>
  <uriAdresses>
      <uriAdress>
          <scheme name="https" />
          <host name="habrahabr.ru" />
          <path>
              <segment>company</segment>
              <segment>it-grad</segment>
              <segment>blog</segment>
              <segment>341486</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="http" />
          <host name="www.example.com" />
          <path>
              <segment>customers</segment>
              <segment>12345</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="http" />
          <host name="www.example.com" />
          <path>
              <segment>customers</segment>
              <segment>12345</segment>
              <segment>orders</segment>
              <segment>98765</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="qaevolution.ru" />
          <path>
              <segment>znakomstvo-s-testirovaniem-api</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="www.contoso.com" />
          <path>
              <segment>Home</segment>
              <segment>Index.htm</segment>
          </path>
          <query>
              <parameter key="q1" value="v1" />
              <parameter key="q2" value="v2" />
          </query>
      </uriAdress>
      <uriAdress>
          <scheme name="http" />
          <host name="aaa.com" />
          <path>
              <segment>temp</segment>
          </path>
          <query>
              <parameter key="key" value="Foo" />
              <parameter key="value" value="Bar" />
              <parameter key="id" value="42" />
          </query>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="www.w3schools.com" />
          <path>
              <segment>html</segment>
              <segment>default.asp</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="http" />
          <host name="www.ninject.org" />
          <path>
              <segment>learn.html</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>ru-ru</segment>
              <segment>dotnet</segment>
              <segment>csharp</segment>
              <segment>programming-guide</segment>
              <segment>concepts</segment>
              <segment>linq</segment>
              <segment>linq-to-xml-overview</segment>
          </path>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>ru-ru</segment>
              <segment>dotnet</segment>
              <segment>api</segment>
              <segment>system.linq.queryable.where</segment>
          </path>
          <query>
              <parameter key="view" value="netframework-4.8" />
          </query>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>en-us</segment>
              <segment>dotnet</segment>
              <segment>api</segment>
              <segment>system.xml.serialization.xmlserializer</segment>
          </path>
          <query>
              <parameter key="view" value="net-6.0" />
          </query>
      </uriAdress>
      <uriAdress>
          <scheme name="https" />
          <host name="metanit.com" />
          <path>
              <segment>python</segment>
              <segment>django</segment>
              <segment>1.1.php</segment>
          </path>
      </uriAdress>
  </uriAdresses>
  ```
  </details>

  <details>
  <summary>See an example of JSON format.</summary>
  
  ```
  [
    {
      "scheme": "https",
      "host": "habrahabr.ru",
      "path": [
        "company",
        "it-grad",
        "blog",
        "341486"
      ]
    },
    {
      "scheme": "http",
      "host": "www.example.com",
      "path": [
        "customers",
        "12345"
      ]
    },
    {
      "scheme": "http",
      "host": "www.example.com",
      "path": [
        "customers",
        "12345",
        "orders",
        "98765"
      ]
    },
    {
      "scheme": "https",
      "host": "qaevolution.ru",
      "path": [
        "znakomstvo-s-testirovaniem-api"
      ]
    },
    {
      "scheme": "https",
      "host": "www.contoso.com",
      "path": [
        "Home",
        "Index.htm"
      ],
      "query": [
        {
          "key": "q1",
          "value": "v1"
        },
        {
          "key": "q2",
          "value": "v2"
        }
      ]
    },
    {
      "scheme": "http",
      "host": "aaa.com",
      "path": [
        "temp"
      ],
      "query": [
        {
          "key": "key",
          "value": "Foo"
        },
        {
          "key": "value",
          "value": "Bar"
        },
        {
          "key": "id",
          "value": "42"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "www.w3schools.com",
      "path": [
        "html",
        "default.asp"
      ]
    },
    {
      "scheme": "http",
      "host": "www.ninject.org",
      "path": [
        "learn.html"
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "ru-ru",
        "dotnet",
        "csharp",
        "programming-guide",
        "concepts",
        "linq",
        "linq-to-xml-overview"
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "ru-ru",
        "dotnet",
        "api",
        "system.linq.queryable.where"
      ],
      "query": [
        {
          "key": "view",
          "value": "netframework-4.8"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "en-us",
        "dotnet",
        "api",
        "system.xml.serialization.xmlserializer"
      ],
      "query": [
        {
          "key": "view",
          "value": "net-6.0"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "metanit.com",
      "path": [
        "python",
        "django",
        "1.1.php"
      ]
    }
  ]
  
  ```
  </details>

- Do not serialize Uri's that do not match the specified `<scheme>://<host>/<path>?<query>`-pattern, log the information by marking the specified strings as not valid for serialization. To log use `NLog.Extensions.Logging` package.

- Pass all tests.
- Demonstrate how it works with an example console application.
- To resolve dependencies use the `Microsoft.Extensions.DependencyInjection` package.
- To configuration console application use `Microsoft.Extensions.Configuration` package.
