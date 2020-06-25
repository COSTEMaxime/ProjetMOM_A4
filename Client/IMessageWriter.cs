using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.MiddlewareService;

namespace Client {
    interface IMessageWriter {
        Message generateMessage(ApplicationInfo info, object[] data);
    }
}
