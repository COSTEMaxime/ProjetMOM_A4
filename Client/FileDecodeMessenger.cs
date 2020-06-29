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
        Dictionary<string, string> filesData;

        public FileDecodeMessenger(User user, ApplicationInfo appInfo, Dictionary<string, string> filesData) {
            this.user = user;
            this.appInfo = appInfo;
            this.filesData = filesData;
        }

        public Message writeMessage() {

            Message msg = new Message();

            object[] data = new object[2];
            data[0] = user.Username;
            data[1] = filesData;

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
