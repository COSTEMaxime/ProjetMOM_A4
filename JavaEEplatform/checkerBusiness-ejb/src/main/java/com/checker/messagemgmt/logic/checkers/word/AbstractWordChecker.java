/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.checkers.word;

/**
 *
 * @author Nico
 */
public abstract class AbstractWordChecker implements IWordChecker {
    
    int invalidChars = 0;
    int totalChars = 0;
    int invalidWords = 0;
    int validWords = 0;
    int totalWords = 0;
    int matchedWords = 0;
    int unmatchedWords = 0;

    @Override
    abstract public boolean isWordInDictionary(String word);

    @Override
    public float check(String txt) {
        return testFileCoherence(txt);
    }

    public float testFileCoherence(String decodedMessage) {
        return testFileCoherence(decodedMessage, null);
        }

    public String[] splitWords(String txt) {
        return txt.split(" |\\.|,|'|\\(|\\)|\\n|\\r");
    }

    public float testFileCoherence(String decodedMessage, String[] dictionaryWords) {
        String sample = decodedMessage.length() > 300 ? decodedMessage.substring(0,300):decodedMessage;
        String[] words = splitWords(sample);
        if (words.length < 6) { //5 words or less in 300 first chars is unlikely
            return 0f;
        }
        for (String word : words) {
            if(word.length() > 4) {
                boolean isValid = checkWord(word);
                if (abortCheck(word, isValid)) { return validWords == 0 ? 0:matchedWords / 10f; }
                if(successCheck()) { return validWords == 0 ? 0:(float)matchedWords / validWords; }
            }
        }
        //System.out.println("done: "+totalChars+" chars, "+invalidChars+" invalid chars ("+(float)invalidChars/totalChars+"%), "+invalidWords+" invalid words ("+(float)invalidWords/words.length+"%), "+matchedWords+" matched");
        //System.out.println("Could not conclude on file validity.");
        return validWords == 0 ? 0:(float)matchedWords / 10f;
    }

    private boolean successCheck() {
        return (validWords > 9 && (float) matchedWords / validWords > 0.5);
    }

    private boolean abortCheck(String word, boolean wordIsValid) {
        if (invalidWords > totalWords / 10 && invalidChars > 9) { //could see the frequency of é,è,ç,à in french to establish the right percentage
            //System.out.println("over 10% invalid words, wrong key, return");
            return true;
        } else {
            if (wordIsValid && word.length() > 3) {
                validWords++;
                //System.out.println("will compare with dictionary :"+ word);
                if (isWordInDictionary(word)) {
                    matchedWords++;
                } else {
                    unmatchedWords++;
                }
                //System.out.println(matched+" matched = "+matchedWords+" unmatched= "+unmatchedWords);
            }
        }
        return (validWords > 9 && (float) matchedWords / validWords < 0.3);
    }

    private boolean checkWord(String word) {
        int invalidCharInWord = 0;
        for (char letter : word.toCharArray()) {
            totalChars++;
            if ((int) letter > 255 || (int) letter < 0 || !("" + letter).matches("[A-zÀ-ú]*[?\\-]*")) {
                //System.out.println("invalid char "+letter+" in word "+ word);
                invalidCharInWord++;
                invalidChars++;
            }
            if (invalidCharInWord > 1) {
                //System.out.println("2 invalid char in word "+word+" , breaking");
                invalidWords++;
                return false;
            }
        }
        return true;
    }
}
