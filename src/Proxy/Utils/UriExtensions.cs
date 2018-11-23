using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using Hydrogen.General.Collections;

namespace Arvan.Proxy.Utils
{
    public static class UriExtensions
    {
        // Credit: code has been copied from:
        // https://stackoverflow.com/questions/829080/how-to-build-a-query-string-for-a-url-in-c
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);

            httpValueCollection.Remove(name);
            httpValueCollection.Add(name, value);

            return BuildUriWithQueryString(uri, httpValueCollection).Uri;
        }
        
        public static Uri AddQueries(this Uri uri, IEnumerable<KeyValuePair<string, string>> queries)
        {
            if (queries == null)
                return uri;
            
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            queries.ForEach(q => httpValueCollection.Set(q.Key, q.Value));

            return BuildUriWithQueryString(uri, httpValueCollection).Uri;
        }

        private static UriBuilder BuildUriWithQueryString(Uri uri, NameValueCollection httpValueCollection)
        {
            var ub = new UriBuilder(uri);

            // this code block is taken from httpValueCollection.ToString() method
            // and modified so it encodes strings with HttpUtility.UrlEncode
            if (httpValueCollection.Count == 0)
                ub.Query = String.Empty;
            else
            {
                var sb = new StringBuilder();

                for (int i = 0; i < httpValueCollection.Count; i++)
                {
                    string text = httpValueCollection.GetKey(i);
                    {
                        text = HttpUtility.UrlEncode(text);

                        string val = (text != null) ? (text + "=") : string.Empty;
                        string[] vals = httpValueCollection.GetValues(i);

                        if (sb.Length > 0)
                            sb.Append('&');

                        if (vals == null || vals.Length == 0)
                            sb.Append(val);
                        else
                        {
                            if (vals.Length == 1)
                            {
                                sb.Append(val);
                                sb.Append(HttpUtility.UrlEncode(vals[0]));
                            }
                            else
                            {
                                for (int j = 0; j < vals.Length; j++)
                                {
                                    if (j > 0)
                                        sb.Append('&');

                                    sb.Append(val);
                                    sb.Append(HttpUtility.UrlEncode(vals[j]));
                                }
                            }
                        }
                    }
                }

                ub.Query = sb.ToString();
            }

            return ub;
        }
    }
}