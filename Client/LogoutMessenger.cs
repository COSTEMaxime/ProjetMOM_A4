using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    class LogoutMessenger : IMessenger {

        User userInfo;
        ApplicationInfo appInfo;

        public LogoutMessenger(User userInfo, ApplicationInfo appInfo) {
            this.userInfo = userInfo;
            this.appInfo = appInfo;
        }

        public MiddlewareService.Message writeMessage() {
            var msg = new MiddlewareService.Message();

            object[] data = new object[1];
            data[0] = userInfo.Username;

            msg.appToken = appInfo.Token;
            msg.appVersion = appInfo.Version;
            msg.operationName = "serviceLogout";
            msg.operationVersion = "";
            msg.operationStatus = false;
            msg.userToken = userInfo.Token;
            msg.info = "";
            msg.data = data;

            return msg;
        }
    }
}
