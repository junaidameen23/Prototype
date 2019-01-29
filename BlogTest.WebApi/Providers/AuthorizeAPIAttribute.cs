using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Filters;

namespace BlogTest.WebApi.Providers
{
    public class AuthorizeAPIAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using <see cref="T:S:System.Web.Http.Filters.AuthorizationFilterAttribute" />.</param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            var security = headers.Any(x => x.Key == "ApiToken");
            if (security)
            {
                var value = headers.FirstOrDefault(x => x.Key == "ApiToken").Value.FirstOrDefault();
                if (value != null)
                {
                    string token = value;
                    if (token == ConfigItems.APIToken)
                    {
                        return;
                    }
                }
            }

            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Response.Content = new StringContent("Security Failed", Encoding.UTF8, "application/json");
            base.OnAuthorization(actionContext);
        }
    }

    /// <summary>
    /// ConfigItems class
    /// </summary>
    public class ConfigItems
    {
        /// <summary>
        /// Gets a value APIToken
        /// </summary>
        public static string APIToken
        {
            get
            {
                return WebConfigurationManager.AppSettings["APIToken"];
            }
        }
    }
}