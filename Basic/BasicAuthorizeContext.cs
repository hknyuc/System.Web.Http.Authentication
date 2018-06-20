using System.Security.Principal;
using System.Web.Http.Controllers;

namespace System.Web.Http.Authentication.Basic
{
    public class BasicAuthorizeContext 
    {
        public HttpActionContext ActionContext { get; }

        public BasicUser BasicUser { get; }

        public BasicAuthorizeContext(HttpActionContext authorizationContext, BasicUser basicUser)
        {
            ActionContext = authorizationContext;
            BasicUser = basicUser;
        }

        public void SetPrincipal(IPrincipal principal)
        {
            this.ActionContext.ControllerContext.RequestContext.Principal = principal;
        }
    }
}
