using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BitMexAPI.Requests.Rest
{
    public abstract class RestRequestBase : HttpRequestMessage
    {
        public RestRequestBase()
        {
            Method = MethodType;
        }

        public abstract bool RequiresAuth { get; }

        public virtual void BuildParameters()
        {
            RequestUri = new Uri(new Uri("https://www.bitmex.com"), Path);
            //RequestUri = new Uri(new Uri("https://testnet.bitmex.com"), Path);
        }

        public string Json { get; set; }
        protected abstract HttpMethod MethodType { get; }
        public abstract string Path { get; }

        protected string BuildQueryData(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            StringBuilder b = new StringBuilder();
            foreach (var item in param)
                b.Append(string.Format("&{0}={1}", item.Key, HttpUtility.UrlEncode(item.Value)));

            try
            { return b.ToString().Substring(1); }
            catch (Exception) { return ""; }
        }

        public virtual string ToQueryString()
        {
            var props = this.GetType().GetProperties().Where(a => a.GetCustomAttributes<DisplayNameAttribute>().Any())
                .Select(
                    a => new
                    {
                        DisplayNameAttr = a.GetCustomAttributes<DisplayNameAttribute>().First(),
                        Prop = a
                    });

            var @params = props.Select(a =>
                {
                    if (a.Prop.PropertyType == typeof(DateTime?))
                    {
                        return $"{a.DisplayNameAttr.DisplayName}={((DateTime?)a.Prop.GetValue(this))?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")}";
                    }

                    return $"{a.DisplayNameAttr.DisplayName}={HttpUtility.UrlEncode(a.Prop.GetValue(this)?.ToString())}";
                });

            return $"{string.Join("&", @params)}";
        }

    }
}