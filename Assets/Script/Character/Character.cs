using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    Inventory inventory;    

    void Awake() {
        inventory = new Inventory();        
    }

    public Character(string name) {

    }
   
}
