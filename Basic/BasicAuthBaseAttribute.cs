using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace System.Web.Http.Authentication.Basic
{
    /// <inheritdoc />
    /// <summary>
    /// Provides basic authentication for ASP.NET application
    /// </summary>
    public abstract class BasicAuthBaseFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
        
            if (AnyBasicValue(actionContext) && IsBasicSchema(actionContext) &&
                !IsAuthenticated(new BasicAuthorizeContext(actionContext, GetBasicUser(actionContext)))) return;
            ExecuteAsInvalid(actionContext);
            return;
        }

        private static bool IsBasicSchema(HttpActionContext filterContext)
        {

            return GetBasicValue(filterContext) != null;

        }

        private static string ConvertFromBase64(string basicValueAsBase64)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(basicValueAsBase64));
        }

        private static BasicUser GetBasicUser(HttpActionContext filterContext)
        {
            return GetBasicUserFromBase64(GetBasicValue(filterContext));
        }

        private static BasicUser GetBasicUserFromBase64(string basicValueAsBase64)
        {
            try
            {
                var r = ConvertFromBase64(basicValueAsBase64);
                if (!r.Contains(":")) return null;
                var sp = r.Split(':');
                if (sp.Length != 2) return null;
                return new BasicUser(sp[0], sp[1]);
            }
            catch (Exception)
            {
                return null;
            }
        }


        private static void ExecuteAsInvalid(HttpActionContext filterContext)
        {
            filterContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }

        private static bool AnyBasicValue(HttpActionContext filterContext)
        {
            return GetBasicValue(filterContext) != null;
        }

        private static string GetBasicValue(HttpActionContext filterContext)
        {
            var auth = filterContext.Request.Headers.Authorization;
            if (auth == null) return null;
            if (!auth.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)) return null;
            return auth.Parameter;
        }


        protected abstract bool IsAuthenticated(BasicAuthorizeContext context);
    }
}
