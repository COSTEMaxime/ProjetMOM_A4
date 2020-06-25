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
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
