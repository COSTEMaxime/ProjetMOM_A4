/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.contract;

/**
 *
 * @author Nico
 */
public class MSG {
    private boolean opStatus;
    private String info;
    private Object[] data;
    private String operationName;
    private String appToken;
    private String userToken;
    private String appVersion;
    private String operationVersion;
    
    public MSG() {
        
    }
    
    public MSG addInfo(String info) {
        this.info = info;
        return this;
    }
    
    public MSG addOperationName(String operationName) {
        this.operationName = operationName;
        return this;
    }
    
    public MSG addData(Object[] data) {
        this.data = data;
        return this;
    }
    
    public MSG addAppToken(String appToken) {
        this.appToken = appToken;
        return this;
    }
    
    public MSG addUserToken(String userToken) {
        this.userToken = userToken;
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
