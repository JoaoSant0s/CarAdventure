using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    Character currentCharacter;

    public Character CurrentCharacter {
        get { return currentCharacter; }
        set { currentCharacter = value; }
    }
}
