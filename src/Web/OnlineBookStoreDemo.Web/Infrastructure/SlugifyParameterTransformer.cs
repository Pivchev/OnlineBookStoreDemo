namespace OnlineBookStoreDemo.Web.Infrastructure
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Threading;
    using Microsoft.AspNetCore.Routing;

    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null)
            {
                return null;
            }

            // Slugify value
            return Regex.Replace(Regex.Replace(Regex.Replace(value.ToString(), @"\s+", "_"), @"\W", string.Empty), "_+", "-").ToLower();
        }
    }
}
