/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.dao;

import java.util.HashMap;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author Nico
 */
public class DAO {
    private static DAO INSTANCE;
    
    @PersistenceContext(unitName = "dao")
    private EntityManager em;
    
    private DAO() {
        
    }
    
    public static DAO getInstance() {
        if(INSTANCE == null) {
            INSTANCE = new DAO();
            return INSTANCE;
        } else {
            return INSTANCE;
        }
    }
    
    public HashMap<Character, Integer> getFrequencyMap() {
        /*I was going to do a stub using mysql but it's very long to do
        and we will switch to Oracle anyway so the stub will return a hard coded map*/
//        List<FrequencyMap> entries = em.createNamedQuery("FrequencyMap.findAll").getResultList();
        HashMap<Character, Integer> frequencyMap = new HashMap<>();
        frequencyMap.put('e', 147);
        frequencyMap.put('a', 79);
        frequencyMap.put('s', 76);
        return frequencyMap;
    }
}
