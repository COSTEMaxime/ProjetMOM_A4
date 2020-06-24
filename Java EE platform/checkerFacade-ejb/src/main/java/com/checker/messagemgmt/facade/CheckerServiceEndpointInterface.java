/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.facade;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

/**
 *
 * @author Nico
 */
@WebService(name = "CheckerEndpoint")
public interface CheckerServiceEndpointInterface {
    @WebMethod(operationName = "checkOperation")
    @WebResult(name = "checkedText")
    Boolean findSecret(@WebParam(name="textToCheck")String txt);
}
