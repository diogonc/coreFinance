using System;

namespace CoreFinance.Domain
{
    public class User : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string propertyUuid, string username, string password, string uuid = null)
        {
            Uuid = string.IsNullOrWhiteSpace(uuid) ? Guid.NewGuid().ToString() : uuid;
            PropertyUuid = propertyUuid;
            Username = username;
            Password = password;
        }

        public void Update(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
