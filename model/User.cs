using System;

namespace model
{
    [Serializable]
    public class User : Entity<long>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return "ID: " + Id + " | Username: " + Username;
        }
    }
}