using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {        

    void Awake() {
        instance = this;
        Collectable.OnCheckCollectable += CollectedItem;
    }

    void OnDestroy() {
        Collectable.OnCheckCollectable -= CollectedItem;
    }

    private static LevelManager instance;
    public static LevelManager Instance {
        get { return instance; }
    }    

    void CollectedItem(Collectable collectable) {                
    }    

}
