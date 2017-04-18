using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level{

    [SerializeField]
    PathController pathDefinition;    

    public PathController PathDefinition() {
        return pathDefinition;
    }    
    
}
