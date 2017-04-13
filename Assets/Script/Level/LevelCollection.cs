using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollection : ScriptableObject {
    [SerializeField]
    Level[] levels;

    public Level[] Levels {
        get { return levels; }
    }   
}
