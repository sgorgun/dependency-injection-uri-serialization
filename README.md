# url-parser-stairway-pattern

<details>
<summary>Text file with Uri addresses.</summary>

```
https://habrahabr.ru/company/it-grad/blog/341486/
http://www.example.com/customers/12345
http://www.example.com/customers/12345/orders/98765
https://qaevolution.ru/znakomstvo-s-testirovaniem-api/
http://
ps://metanit.com/python/django/1.1.php
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

<details>
<summary>XML file with Uri addresses.</summary>

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
        <scheme name="ps" />
        <host name="metanit.com" />
        <path>
            <segment>python</segment>
            <segment>django</segment>
            <segment>1.1.php</segment>
        </path>
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
<summary>XML file with Uri addresses.</summary>
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
    "scheme": "ps",
    "host": "metanit.com",
    "path": [
      "python",
      "django",
      "1.1.php"
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
