/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers;

import com.checker.messagemgmt.logic.checkers.character.CharacterChecker;
import com.checker.messagemgmt.logic.checkers.word.ListWordChecker;

/**
 *
 * @author Nico
 */
public class FrenchChecker implements IChecker{

    @Override
    public boolean check(String txt) {
        if(new CharacterChecker().check(txt)) {
            new ListWordChecker().check(txt);
        }
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
