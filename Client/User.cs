using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class User : GlobalInformation {
        
        public User() {
            Username = "";
            Password = "";
            Token = "";
            Email = "";
            groups = new List<string>();
            groups.Append("USER");
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public List<string> groups { get; set; }
    }
}
