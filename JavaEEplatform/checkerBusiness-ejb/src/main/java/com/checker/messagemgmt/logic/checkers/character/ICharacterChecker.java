/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers.character;

import com.checker.messagemgmt.logic.checkers.IChecker;

/**
 *
 * @author Nico
 */
public interface ICharacterChecker extends IChecker{
    boolean frequencyAnalysis(char c, String txt);
}
