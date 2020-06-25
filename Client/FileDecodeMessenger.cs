using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class FileDecodeMessenger : IMessenger {

        User user;
        ApplicationInfo appInfo;

        public FileDecodeMessenger(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;
        }

        public Message writeMessage() {
            throw new NotImplementedException();
        }
    }
}
