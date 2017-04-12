using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {


    Inventory inventory;

    Score score;

    void Awake() {
        inventory = new Inventory();
        score = new Score();
    }

    public Character(string name) {

    }
    
    	
}
