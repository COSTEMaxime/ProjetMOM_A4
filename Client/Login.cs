using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    class Login : IAction {

        User user;
        ApplicationInfo appInfo;

        IMessenger messenger;

        public Login(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;

            messenger = new LoginMessenger(user, appInfo);
        }

        public void carryOut() {
            MiddlewareService.Message msg = messenger.writeMessage();

            Postman postman = new Postman();
            postman.sendMessage(msg);
        }
    }
}
