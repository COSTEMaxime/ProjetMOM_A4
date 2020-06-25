using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class UserAction : IAction {

        User user;
        ApplicationInfo appInfo;

        IMessenger messenger;

        public UserAction(IMessenger messenger) {
            this.messenger = messenger;
        }

        public void carryOut() {
            MiddlewareService.Message msg = messenger.writeMessage();

            Postman postman = new Postman();
            postman.sendMessage(msg);
        }
    }
}
