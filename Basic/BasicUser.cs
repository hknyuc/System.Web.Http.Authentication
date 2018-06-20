namespace System.Web.Http.Authentication.Basic
{
    /// <summary>
    /// User information of Authentication header
    /// </summary>
    public class BasicUser
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; }
        public BasicUser(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
