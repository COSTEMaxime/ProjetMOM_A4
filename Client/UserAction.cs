using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class UserAction : IAction {

        IMessenger messenger;

        public UserAction(IMessenger messenger) {
            this.messenger = messenger;
        }

        public Message carryOut() {
            MiddlewareService.Message msg = messenger.writeMessage();

            Postman postman = new Postman();
            return postman.sendMessage(msg);
        }
    }
}
