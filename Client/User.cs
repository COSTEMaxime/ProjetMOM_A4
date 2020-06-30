using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    public class User {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string[] groups { get; set; }
        public bool IsLoggedIn { get; set; }

        public User() {
            Username = "";
            Password = "";
            Token = "";
            Email = "";
            IsLoggedIn = false;
            groups = new string[1];
            groups[0] = "admin";

            // groups = new List<string>();
            // groups.Add("USER");
        }
    }
}
