/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic;

import com.checker.messagemgmt.contract.MSG;
import com.checker.messagemgmt.logic.checkers.FrenchChecker;
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
import org.tempuri.IServiceEntryPoint;
import org.tempuri.ServiceEntryPoint;

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
            String XMLmesssage = message.getBody(String.class);
            jaxbContext = JAXBContext.newInstance(MSG.class);
            Unmarshaller jaxbUnmarshaller = jaxbContext.createUnmarshaller();
            StringReader reader = new StringReader(XMLmesssage);
            msg = (MSG) jaxbUnmarshaller.unmarshal(reader);
            System.out.println(msg.getInfo());
            String messageToCheck = (String) msg.getData()[0];
            if(checkMessage(messageToCheck)) {
                String secret = findSecret(messageToCheck);
                if(secret != "") {
//                    String key = (String) msg.getData()[1];
                    String key = (String) msg.getData()[0];
                    sendResponse(key ,messageToCheck, secret);
                } else {
                    //TODO log file
                    System.out.println("File was in French but no secret was found");
                }
            }
        } catch (JAXBException | JMSException ex) {
            Logger.getLogger(MessageProcessor.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private boolean checkMessage(String txt) {
        return new FrenchChecker().check(txt);
    }
    
    
    private String findSecret(String txt) {
        /**
         * We only know that the secret is preceeded by "l’information secrète"
         * So we have to make a guess as to where it stops.
         * My guess is that the identifier and the secret are on the same line.
         */
        String[] lines = txt.split("\r");
        for(String line : lines) {
            if(line.contains("secrete")) {
                return line;
            }
        }
        return "";
    }
    
    private double calculateConfidence(String sample, String wholeText) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    private void sendResponse(String key , String messageToCheck, String secret) {
        System.out.println("Secret found, will send the secret : "+secret);
        MSG msg = new MSG.MSGBuilder().setData(new Object[] {key , messageToCheck, secret}).build();
//        wcfEndpoint.sendMessage(msg);
        org.datacontract.schemas._2004._07.contractwcf.Message message = convertMessage(msg);
        ServiceEntryPoint ep = new ServiceEntryPoint();
        IServiceEntryPoint iep;
        iep = ep.getIServiceHttp();
        iep.accessService(message);
        System.out.println("called service");
//        ep.getSvc().accessService(message);
//        service.accessService(message);
    }
    
    private org.datacontract.schemas._2004._07.contractwcf.Message convertMessage(MSG msg) {
        org.datacontract.schemas._2004._07.contractwcf.Message message = new org.datacontract.schemas._2004._07.contractwcf.Message();
//        message.setData(msg.getData());
        return message;
    }
}
