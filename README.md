# url-parser-stairway-pattern

## Task Description

The system of the types that describe the logic of the export of the string representation of the data in the other format are present in solution.

![](/Images/Architecture1.png)

Use this types for the solution following task.

The some receiver obtains, line by line, information about Uri's that represent of the form `<scheme>://<host>/<path>?<query>`. Where   
  - `path` may consist of segments of the form `segment1/segment2/.../segmentN`, 
  - `query` consist pairs of the form `key1=value1&...&keyK=valueK`. 

For example, see content of the `uri-addresses.txt` file
<details>
<summary><b>uri-addresses.txt</b> file with Uri addresses.</summary>

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

Сonsider getting data from both text file and memory.

![](/Images/Architecture3.png)

Develop a type system for exporting data that represent as a string into other format, for example XML or JSON format - use following technologies:
  - XmlWrite class
  - XmlSerializer class
  - XML-DOM model
  - X-DOM model
  - JsonSerializer.

![](/Images/Architecture2.png)

XML format for the data in the `uri-addresses.txt` file will be presented in the form
<details>
<summary><b>uri-addresses.xml</b> file with Uri addresses.</summary>

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

JSON format for the data in the `uri-addresses.txt` file will be presented in the form

<details>
<summary><b>uri-addresses.json</b> file with Uri addresses.</summary>

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
