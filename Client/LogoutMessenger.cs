using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class LogoutMessenger : IMessenger {
        public Message writeMessage(ApplicationInfo info, object[] data) {
            throw new NotImplementedException();
        }
    }
}
