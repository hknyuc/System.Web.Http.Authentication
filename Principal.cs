using System.Security.Principal;

namespace System.Web.Http.Authentication
{
    /// <summary>
    /// Usable default principal
    /// </summary>
    public class Principal : IPrincipal
    {
        public IIdentity Identity { get; }

        private readonly string[] _roles;
        public Principal(IIdentity identity,params string[] roles)
        {
            Identity = identity;
            this._roles = roles;

        }
        public bool IsInRole(string role)
        {
            foreach (var r in _roles)
                if (r == role) return true;
            return false;
        }

      
    }
}
