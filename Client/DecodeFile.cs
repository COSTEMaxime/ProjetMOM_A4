using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class DecodeFile : IAction {

        User user;
        ApplicationInfo appInfo;

        IMessenger messenger;

        public DecodeFile(User user, ApplicationInfo appInfo) {
            this.user = user;
            this.appInfo = appInfo;

            messenger = new FileDecodeMessenger(user, appInfo);
        }

        public void carryOut() {
            throw new NotImplementedException();
        }
    }
}
