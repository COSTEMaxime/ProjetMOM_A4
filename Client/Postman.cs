﻿using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    class Postman {

        public Message sendMessage(Message msg) {
            ServiceEntryPointClient client = new ServiceEntryPointClient();

            Message response;

            try {
                response = client.AccessService(msg);
            } catch(System.ServiceModel.EndpointNotFoundException) {
                response = new Message();
                response.operationStatus = false;
                response.info = "Endpoint not found.";
            } catch(System.TimeoutException) {
                response = new Message();
                response.operationStatus = false;
                response.info = "Request timed out.";
            }

            return response;
        }
    }
}
