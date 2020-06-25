using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    interface IMessenger {
        Message writeMessage(ApplicationInfo info, object[] data);
    }
}
