/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers.word;

import com.checker.messagemgmt.logic.dao.DAO;
/**
 *
 * @author Nico
 */
public class DatabaseWordChecker extends AbstractWordChecker{

    @Override
    public boolean isWordInDictionary(String word) {
        return DAO.getInstance().isInDictionary(word);
    }
}
