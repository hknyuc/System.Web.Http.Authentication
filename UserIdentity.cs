namespace System.Web.Http.Authentication
{
    /// <summary>
    /// Default user identity
    /// </summary>
    public class UserIdentity
    {
        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }

        /// <summary>
        /// Extendable user information property
        /// </summary>
        public object User { get; }

        public UserIdentity(string name, bool isAuthenticated, string type, object user)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
            User = user;
            AuthenticationType = type;
        }

        public UserIdentity(string name, bool isAuthenticated)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
        }
    }
}
