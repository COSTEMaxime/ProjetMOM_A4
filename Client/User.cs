using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class User {
        
        public User() {
            username = "";
            password = "";
        }

        public string username { get; set; }
        public string password { get; set; }
    }
}
