/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.facade;

import javax.ejb.Stateless;
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

    @Override
    public Boolean findSecret(String txt) {
        System.out.println(txt);
        return true;
    }

    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
