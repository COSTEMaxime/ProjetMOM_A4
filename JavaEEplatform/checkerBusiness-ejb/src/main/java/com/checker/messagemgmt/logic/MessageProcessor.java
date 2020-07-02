/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic;

import com.checker.messagemgmt.contract.MSG;
import com.checker.messagemgmt.logic.checkers.FrenchChecker;
import com.microsoft.schemas._2003._10.serialization.ObjectFactory;
import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfanyType;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;
import java.util.List;
import java.util.logging.FileHandler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.ObjectMessage;
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
        try {
            ObjectMessage m = (ObjectMessage) message;
            msg = (MSG) (m).getObject();
            String messageToCheck = new String((byte[]) msg.getData()[3], StandardCharsets.UTF_8);
            float confidence = 1;//checkMessage(messageToCheck);
            if (confidence > 0.5f) {
                String secret = findSecret(messageToCheck);
                secret="hello sweetie";
                if (secret != "") {
                    String key = (String) msg.getData()[1];
                    logFile("File "+msg.getData()[0]
                            +" was in French. Secret was :"+secret+". Key : " + msg.getData()[1]
                            +" Confdence : " + confidence, Level.FINEST);
                    sendResponse(key, messageToCheck, secret, msg);
                } else {
                    logFile("File "+msg.getData()[0]
                            +" was in French but no secret was found. Key : " + msg.getData()[1]
                            +" Confdence : " + confidence, Level.WARNING);
//                    System.out.println("File was in French but no secret was found");
                }
            }
        } catch (JMSException ex) {
            Logger.getLogger(MessageProcessor.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private float checkMessage(String txt) {
        return new FrenchChecker().check(txt);
    }

    private String findSecret(String txt) {
        /**
         * We only know that the secret is preceeded by "l’information secrète"
         * So we have to make a guess as to where it stops. My guess is that the
         * identifier and the secret are on the same line.
         */
        String[] lines = txt.split("\r");
        for (String line : lines) {
            if (line.contains("l'information secrète")) {
                return line;
            }
        }
        return "";
    }

    private double calculateConfidence(String sample, String wholeText) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    private void sendResponse(String key, String messageToCheck, String secret, MSG msg) {
        System.out.println("Secret found, will send the secret : " + secret);
        float cert = 0.99f;
        MSG msg2 = new MSG.MSGBuilder().setData(new Object[]{
            msg.getData()[0],
            msg.getData()[1],
            msg.getData()[2],
            secret,
            cert
        }).setAppToken(msg.getAppToken()).setOpStatus(true).build();
        org.datacontract.schemas._2004._07.contractwcf.Message message = convertMessage(msg2);
        ServiceEntryPoint ep = new ServiceEntryPoint();
        IServiceEntryPoint iep;
        iep = ep.getIServiceHttp();
        iep.accessService(message);
        System.out.println("called service");
//        ep.getSvc().accessService(message);
//        service.accessService(message);
    }
    
    private org.datacontract.schemas._2004._07.contractwcf.Message convertMessage(MSG msg) {
        org.datacontract.schemas._2004._07.contractwcf.ObjectFactory factory = new org.datacontract.schemas._2004._07.contractwcf.ObjectFactory();
        org.datacontract.schemas._2004._07.contractwcf.Message message = factory.createMessage();
        message.setAppToken(factory.createMessageAppToken("java"));
        message.setOperationStatus(Boolean.FALSE);
        com.microsoft.schemas._2003._10.serialization.arrays.ObjectFactory factoryOfArray = new com.microsoft.schemas._2003._10.serialization.arrays.ObjectFactory();
        ArrayOfanyType arr = factoryOfArray.createArrayOfanyType();
        List<Object> value = arr.getAnyType();
        value.addAll(Arrays.asList(msg.getData()));
        message.setData(factory.createMessageData(arr));
        return message;
    }

    private void logFile(String textToLog, Level logLevel) {
        Logger logger = Logger.getLogger("MyLog");
        FileHandler fh;
        try {
            fh = new FileHandler("checkResults.log", true);
            SimpleFormatter formatter = new SimpleFormatter();
            fh.setFormatter(formatter);
            logger.addHandler(fh);
        } catch (SecurityException | IOException e) {
            e.printStackTrace();
        }
        logger.log(logLevel, textToLog);
    }
}
