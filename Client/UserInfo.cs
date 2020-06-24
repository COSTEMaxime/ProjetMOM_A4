using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class UserInfo {
        
        public UserInfo() {
            username = "";
            password = "";
            currentToken = "";
        }

        private string username { get; set; }
        private string password { get; set; }
        private string currentToken { get; set; }
    }
}
