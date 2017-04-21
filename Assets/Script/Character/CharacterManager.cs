using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public delegate void SetCarCamera();
    public static event SetCarCamera OnSetCarCamera;

    private static CharacterManager instance;
    public static CharacterManager Instance {
        get { return instance; }
    }    

    void Awake () {
        instance = this;                
    }    
    
}
