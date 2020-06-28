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
        string[] filesContent;

        public FileDecodeMessenger(User user, ApplicationInfo appInfo, string[] filesContent) {
            this.user = user;
            this.appInfo = appInfo;
            this.filesContent = filesContent;
        }

        public Message writeMessage() {

            Message msg = new Message();

            object[] data = new object[3];
            data[0] = user.Username;
            data[1] = user.Token;
            data[2] = filesContent;

            msg.appToken = appInfo.Token;
            msg.appVersion = appInfo.Version;
            msg.operationName = "serviceDecodeFile";
            msg.operationVersion = "";
            msg.operationStatus = false;
            msg.userToken = user.Token;
            msg.info = "";
            msg.data = data;

            return msg;
        }
    }
}
