using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    Character currentCharacter;

    public Character CurrentCharacter {
        get { return currentCharacter; }
        set { currentCharacter = value; }
    }

    void Awake() {
        Collectable.OnCheckCollectable += UpdateInventory;        
    }

    void OnDestroy() {
        Collectable.OnCheckCollectable -= UpdateInventory;
    }

    void UpdateInventory(Collectable collectable) {
        currentCharacter.UpdateGold(collectable.ValueCollectable);        
    }

}
