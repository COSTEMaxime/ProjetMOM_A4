/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.checker.messagemgmt.logic.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Nico
 */
public class DAO {

    private static DAO INSTANCE;
    private Connection conn;
    HashMap<Character, Integer> frequencyMap;
    private List<String> dictionary;

    private DAO() {
        try {
            Class.forName("oracle.jdbc.driver.OracleDriver");
            conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:mom", "admin", "admin");
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(DAO.class.getName()).log(Level.SEVERE, null, ex);
        }

        try {
            frequencyMap = new HashMap<>();
            String queryString = "select * from frequency";
            Statement stmt = conn.createStatement();
            ResultSet result = stmt.executeQuery(queryString);
            while (result.next()) {
                String c = result.getString("letter");
                int frequency = result.getInt("frequency");
                frequencyMap.put(c.charAt(0), frequency);
            }
        } catch (SQLException ex) {
            Logger.getLogger(DAO.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public static DAO getInstance() {
        if (INSTANCE == null) {
            INSTANCE = new DAO();
            return INSTANCE;
        } else {
            return INSTANCE;
        }
    }

    public HashMap<Character, Integer> getFrequencyMap() {
        return frequencyMap;
    }

    public boolean isInDictionary(String word) {
        Statement stmt = null;
        ResultSet result = null;
        try {
            word = word.replace("'", "''");
            String queryString = "select word from dictionary where matches(word, '" + word + "')>0";
            stmt = conn.createStatement();
            result = stmt.executeQuery(queryString);
            if (result.next()) {
//                String found = result.getString("word");
//                System.out.println(found);
                return true;
            } else {
                return false;
            }

        } catch (SQLException ex) {
            Logger.getLogger(DAO.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                if (result != null) {
                    result.close();
                }
            } catch (Exception e) {
            };
            try {
                if (stmt != null) {
                    stmt.close();
                }
            } catch (Exception e) {
            };
        }
        return false;
    }

    public List<String> getDictionary() {
        if (dictionary != null) {
            return dictionary;
        } else {
            return fetchDictionary();
        }
    }

    private List<String> fetchDictionary() {

        Statement stmt = null;
        ResultSet result = null;
        List<String> dict = new ArrayList<>();
        try {
            String queryString = "select word from dictionary";
            stmt = conn.createStatement();
            result = stmt.executeQuery(queryString);
            while (result.next()) {
                String found = result.getString("word");
                dict.add(found);
            }
        } catch (SQLException ex) {
            Logger.getLogger(DAO.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                if (result != null) {
                    result.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
            } catch (Exception e) {
            };
        }
        return dict;
    }
}
