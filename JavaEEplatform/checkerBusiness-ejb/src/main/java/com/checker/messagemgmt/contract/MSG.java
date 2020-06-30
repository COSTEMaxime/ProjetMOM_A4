/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.contract;

import java.io.Serializable;

/**
 *
 * @author Nico
 */
public class MSG implements Serializable{
    private static final long serialVersionUID = 908336348;
    public boolean opStatus;
    public String info;
    public Object[] data;
    public String operationName;
    public String appToken;
    public String userToken;
    public String appVersion;
    public String operationVersion;


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
