using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class RegisterMessenger : IMessenger {

        User user;
        ApplicationInfo appInfo;

        public RegisterMessenger(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;
        }

        public Message writeMessage() {
            throw new NotImplementedException();
        }
    }
}
