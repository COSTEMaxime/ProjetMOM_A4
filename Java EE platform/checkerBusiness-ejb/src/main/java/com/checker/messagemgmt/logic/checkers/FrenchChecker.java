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
            return new ListWordChecker().check(txt);
        }
        return false;
    }
    
}
