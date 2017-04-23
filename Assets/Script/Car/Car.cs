using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    [SerializeField]
    float life = 10f;
 
    Character currentCharacter;
    Claw claw;
    const float maxLife = 10f;    

    public Character CurrentCharacter {
        get { return currentCharacter; }
        set { currentCharacter = value; }
    }

    internal float Life {
        get { return life; }
        set { life = value; }
    }

    public Claw Claw {
        get { return claw; }
        set { claw = value; }
    }

    internal void IncrementLife(float addiction) {
        life += addiction;
        life = Mathf.Min(life, maxLife);
    }
    internal void ReduceLife(float damage) {
        life -= damage;
        life = Mathf.Max(life, 0f);
        Debug.Log(life);
    }

    void Awake() {        
        currentCharacter = new Character("Player");
    }    

}
