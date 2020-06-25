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

            Message msg = new Message();

            object[] data = new object[4];
            data.Append(user.Username);
            data.Append(user.Password);
            data.Append(user.Email);
            data.Append(user.groups);

            msg.appToken = appInfo.Token;
            msg.appVersion = appInfo.Version;
            msg.operationName = "serviceRegister";
            msg.operationVersion = "";
            msg.operationStatus = false;
            msg.userToken = user.Token;
            msg.info = "";
            msg.data = data;

            return msg;
        }
    }
}
