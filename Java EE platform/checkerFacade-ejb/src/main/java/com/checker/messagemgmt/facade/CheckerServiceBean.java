/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.facade;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.Queue;
import javax.jws.WebService;

/**
 *
 * @author Nico
 */
@Stateless
@WebService(
        endpointInterface = "com.checker.messagemgmt.facade.CheckerServiceEndpointInterface",
        portName = "CheckerPort",
        serviceName = "CheckerService"
)

public class CheckerServiceBean implements CheckerServiceEndpointInterface {

    @Inject
    private JMSContext context;

    @Resource(lookup = "jms/messageQueue")
    private Queue messageQueue;

    @Override
    public boolean findSecret(String serializedMsg) {
        sendMessage(serializedMsg);
        return true;
    }

    private void sendMessage(String serializedMsg) {
        context.createProducer().send(messageQueue, serializedMsg);
    }
}
