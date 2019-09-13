using System;
using System.Text;
using System.Web;
using System.Web.Http.Description;

namespace JobAdsCheckoutSystemWeb.Areas.HelpPage
{
    public static class ApIdescriptionExtensions
    {
        /// <summary>
        /// Generates an URI-friendly Id for the <see cref="ApIdescription"/>. E.g. "Get-Values-Id_name" instead of "GetValues/{Id}?name={name}"
        /// </summary>
        /// <param name="description">The <see cref="ApIdescription"/>.</param>
        /// <returns>The Id as a string.</returns>
        public static string GetFriendlyId(this ApIdescription description)
        {
            string path = description.RelativePath;
            string[] urlParts = path.Split('?');
            string localPath = urlParts[0];
            string queryKeyString = null;
            if (urlParts.Length > 1)
            {
                string query = urlParts[1];
                string[] queryKeys = HttpUtility.ParseQueryString(query).AllKeys;
                queryKeyString = String.Join("_", queryKeys);
            }

            StringBuilder friendlyPath = new StringBuilder();
            friendlyPath.AppendFormat("{0}-{1}",
                description.HttpMethod.Method,
                localPath.Replace("/", "-").Replace("{", String.Empty).Replace("}", String.Empty));
            if (queryKeyString != null)
            {
                friendlyPath.AppendFormat("_{0}", queryKeyString.Replace('.', '-'));
            }
            return friendlyPath.ToString();
        }
    }
}