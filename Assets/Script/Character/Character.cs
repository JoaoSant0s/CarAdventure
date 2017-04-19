using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    private Inventory inventory;
    private string name;     

    public Character(string name) {
        this.name = name;
        inventory = new Inventory();
    }

    internal void UpdateGold(int number) {
        inventory.UpdateGold(number);
    }    

}
