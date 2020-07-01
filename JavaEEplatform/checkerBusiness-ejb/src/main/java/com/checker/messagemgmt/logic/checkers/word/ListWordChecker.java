/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers.word;

import com.checker.messagemgmt.logic.dao.DAO;
import java.util.HashSet;
import java.util.List;

/**
 *
 * @author Nico
 */
public class ListWordChecker extends AbstractWordChecker {

    @Override
    public boolean isWordInDictionary(String word) {
        List<String> dict = DAO.getInstance().getDictionary();
        HashSet<String> dictSet = new HashSet<>(dict);
        return dictSet.contains(word);
    }
}
