/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers.character;

import com.checker.messagemgmt.logic.dao.DAO;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

/**
 *
 * @author Nico
 */
public class CharacterChecker implements ICharacterChecker {
    private final static int PERCENTAGE_DECIMAL_FIGURES = 2;

    @Override
    public boolean frequencyAnalysis(char c, String txt) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public float check(String txt) {
        String sample = txt.length() > 300 ? txt.substring(0,300):txt;
        return frequencyPretest(sample);
    }

    private HashMap<Character, Integer> getFrequencies() {
        return DAO.getInstance().getFrequencyMap();
    }

    private char[] getCheckableChars() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    private int getFrequency(char c) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    private Map<Integer, Long> countAllChars(String[] words) {
       return Arrays.stream(words)
                .flatMapToInt(String::chars)
                .filter(Character::isLetter)
                .boxed()
                .collect(Collectors.groupingBy(Function.identity(), Collectors.counting()));
    }

    private boolean isfrequencyCoherent(int totalMeasuredPercentage, int totalExpectedPercentage) {

        if (totalMeasuredPercentage*1.5 < totalExpectedPercentage) { //50% uncertainty should be plenty to avoid false negative
            System.out.println("-Inplausible frequency. Measured "+totalMeasuredPercentage+"%, expected "+totalExpectedPercentage+"%.");
            return false;
        } else {
                System.out.println("+Plausible frequency. Measured "+totalMeasuredPercentage+"%, expected "+totalExpectedPercentage+"%.");
            return true;
        }
    }
    
    private float calculateCoherance(int totalMeasuredPercentage, int totalExpectedPercentage) {
        int delta = Math.abs(totalExpectedPercentage - totalMeasuredPercentage);
        return 1-((float)delta / totalExpectedPercentage);
    }

    public float frequencyPretest(String txt) {
        int totalExpectedPercentage = 0;
        int totalMeasuredPercentage = 0;
        String[] words = getWords(txt); //punctuation is excluded from the count
        Map<Integer, Long> letterCountMap = countAllChars(words);
        HashMap<Character, Integer> frequencyMap = getFrequencies();
        
        for (HashMap.Entry< Character, Integer> entry : frequencyMap.entrySet()) {  
            char c = entry.getKey();
            int charInt = c; //easier to compare ints so we convert our char
            int percentage = entry.getValue(); //could be in part per thousand or in ppm depending on the database
            
            if(!letterCountMap.containsKey(charInt)) {
                System.out.println("-Inplausible frequency. No "+c+" found.");
                return 0.0f;
            }
            totalExpectedPercentage += percentage;
            /*
            
            */
            try {
                totalMeasuredPercentage += (Math.pow(10, 1+PERCENTAGE_DECIMAL_FIGURES) * (letterCountMap.get(charInt)) / txt.length());                
            } catch (ArithmeticException ex) {
                System.out.println(ex);
            }
        }
//        return isfrequencyCoherent(totalMeasuredPercentage, totalExpectedPercentage);
        return calculateCoherance(totalMeasuredPercentage, totalExpectedPercentage);
    }
    
    public String[] getWords(String txt) {
        return txt.split(" |\\.|,|'|\\(|\\)|\\n|\\r");
    }
}
