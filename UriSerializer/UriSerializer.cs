namespace UriSerializer
{
    public static class UriSerializer
    {
        public static UriAddresses ToSerializableObject(this Uri address)
        {
            UriAddresses obj = new UriAddresses
            {
                scheme = address.Scheme,
                host = address.Host,
                path = new List<string>(
                    from line in address.Segments
                    where line.Length > 1
                    select line.TrimEnd('/')),
                query = new List<QueryParameter>(
                    from query in address.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries)
                    let elements = query.Split('=')
                    select new QueryParameter
                    {
                        key = elements[0],
                        value = elements.Length > 1 ? elements[1] : null,
                    }),
            };

            return obj;
        }
    }
}
