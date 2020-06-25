/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.contract;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Nico
 */
@XmlRootElement
    @XmlAccessorType(XmlAccessType.FIELD)
public class MSG {
    @XmlElement
    private boolean opStatus;
    @XmlElement
    private String info;
    @XmlElement
    private Object[] data;
    @XmlAttribute
    private String operationName;
    @XmlElement
    private String appToken;
    @XmlElement
    private String userToken;
    @XmlElement
    private String appVersion;
    @XmlElement
    private String operationVersion;


    public static class MSGBuilder {

        private boolean opStatus;
        private String info;
        private Object[] data;
        private String operationName;
        private String appToken;
        private String userToken;
        private String appVersion;
        private String operationVersion;

        public MSGBuilder() {

        }

        public boolean isOpStatus() {
            return opStatus;
        }

        public MSGBuilder setOpStatus(boolean opStatus) {
            this.opStatus = opStatus;
            return this;
        }

        public String getInfo() {
            return info;
        }

        public MSGBuilder setInfo(String info) {
            this.info = info;
            return this;
        }

        public Object[] getData() {
            return data;
        }

        public MSGBuilder setData(Object[] data) {
            this.data = data;
            return this;
        }

        public String getOperationName() {
            return operationName;
        }

        public MSGBuilder setOperationName(String operationName) {
            this.operationName = operationName;
            return this;
        }

        public String getAppToken() {
            return appToken;
        }

        public MSGBuilder setAppToken(String appToken) {
            this.appToken = appToken;
            return this;
        }

        public String getUserToken() {
            return userToken;
        }

        public MSGBuilder setUserToken(String userToken) {
            this.userToken = userToken;
            return this;
        }

        public String getAppVersion() {
            return appVersion;
        }

        public MSGBuilder setAppVersion(String appVersion) {
            this.appVersion = appVersion;
            return this;
        }

        public String getOperationVersion() {
            return operationVersion;
        }

        public MSGBuilder setOperationVersion(String operationVersion) {
            this.operationVersion = operationVersion;
            return this;
        }

        public MSG build() {
            MSG msg = new MSG();
            msg.opStatus = this.opStatus;
            msg.info = this.info;
            msg.data = this.data;
            msg.operationName = this.operationName;
            msg.appToken = this.appToken;
            msg.userToken = this.userToken;
            msg.appVersion = this.appVersion;
            msg.operationVersion = this.operationVersion;
            return msg;
        }
    }

    private MSG() {

    }

    public boolean isOpStatus() {
        return opStatus;
    }

    public String getInfo() {
        return info;
    }

    public Object[] getData() {
        return data;
    }

    public String getOperationName() {
        return operationName;
    }

    public String getAppToken() {
        return appToken;
    }

    public String getUserToken() {
        return userToken;
    }

    public String getAppVersion() {
        return appVersion;
    }

    public String getOperationVersion() {
        return operationVersion;
    }
    
    
}
