# url-parser-stairway-pattern


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
