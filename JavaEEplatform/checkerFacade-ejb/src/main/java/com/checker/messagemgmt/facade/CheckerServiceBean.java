/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.facade;

import com.checker.messagemgmt.contract.MSG;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.inject.Inject;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.ObjectMessage;
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
    public boolean findSecret(MSG message) {
        sendMessage(message);
        return true;
    }

    private void sendMessage(MSG message) {
        try {
            ObjectMessage m = context.createObjectMessage();
            m.setObject(message);
            context.createProducer().send(messageQueue, m);
        } catch (JMSException ex) {
            Logger.getLogger(CheckerServiceBean.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
