/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic;

import com.checker.messagemgmt.contract.MSG;
import com.checker.messagemgmt.logic.checkers.FrenchChecker;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.IOException;
import java.io.StringReader;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;

/**
 *
 * @author Nico
 */
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "jms/messageQueue")
    ,
        @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class MessageProcessor implements MessageListener {

    public MessageProcessor() {
    }

    @Override
    public void onMessage(Message message) {
        MSG msg;
        JAXBContext jaxbContext;
        try {
            String messsageToCheck = message.getBody(String.class);
            jaxbContext = JAXBContext.newInstance(MSG.class);
            Unmarshaller jaxbUnmarshaller = jaxbContext.createUnmarshaller();
            StringReader reader = new StringReader(messsageToCheck);
            msg = (MSG) jaxbUnmarshaller.unmarshal(reader);
            System.out.println(msg.getInfo());
            checkMessage((String) msg.getData()[0]);
        } catch (JAXBException | JMSException ex) {
            Logger.getLogger(MessageProcessor.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private boolean checkMessage(String txt) {
        new FrenchChecker().check(txt);
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    private String findSecret(String txt) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    private double calculateConfidence(String sample, String wholeText) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
