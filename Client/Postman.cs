using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class Postman {

        public Message sendMessage(Message msg) {
            ServiceEntryPointClient client = new ServiceEntryPointClient();
            return client.AccessService(msg);
        }
    }
}
