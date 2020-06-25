using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class LoginMessenger : IMessenger {

        User user;
        ApplicationInfo appInfo;

        public LoginMessenger(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;
        }

        public Message writeMessage() {

            Message msg = new Message();

            msg.appToken = appInfo.Token;
            msg.appVersion = appInfo.Version;
            msg.operationName = "serviceLogin";
            msg.operationVersion = "";
            msg.operationStatus = false;
            msg.userToken = user.Token;
            msg.info = "";

            return msg;
        }
    }
}
