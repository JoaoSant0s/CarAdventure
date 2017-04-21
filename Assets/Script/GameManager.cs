using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    string charactersName;

    [SerializeField]
    CharacterManager characterManager;    

    [SerializeField]
    LevelManager levelManager;

    private static GameManager instance;
    public static GameManager Instance {
        get { return instance; }
    }

    void Awake() {
        instance = this;
    }    
		
}
