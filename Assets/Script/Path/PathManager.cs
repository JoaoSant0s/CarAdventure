using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {    

    private PathController currentPath;    
    private static PathManager instance;
    public static PathManager Instance {
        get { return instance; }
    }    

    void Awake() {
        instance = this;        
    }    
  
    internal void LoadPath(PathController pathDefinition) {                 
    }     
}
