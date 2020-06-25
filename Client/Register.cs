using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class Register : IAction {

        User user;
        ApplicationInfo appInfo;

        IMessenger messenger;

        public Register(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;

            messenger = new RegisterMessenger(user, appInfo);
        }

        public void carryOut() {
            throw new NotImplementedException();
        }
    }
}
