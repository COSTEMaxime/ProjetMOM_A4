/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers;

import com.checker.messagemgmt.logic.checkers.character.CharacterChecker;
import com.checker.messagemgmt.logic.checkers.word.DatabaseWordChecker;

/**
 *
 * @author Nico
 */
public class FrenchChecker implements IChecker{

    @Override
    public float check(String txt) throws ArithmeticException{
        float frequencyCertainty = new CharacterChecker().check(txt);
        if( frequencyCertainty> 0.5f) {
            return new DatabaseWordChecker().check(txt);
        }
        return frequencyCertainty;
    }
    
}
