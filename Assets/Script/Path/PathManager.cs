using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

    [SerializeField]
    Transform pathDestiny;

    private PathController currentPath;    
    private static PathManager instance;
    public static PathManager Instance {
        get { return instance; }
    }    

    void Awake() {
        instance = this;        
    }    
  
    internal void LoadPath(PathController pathDefinition) {
        ObjectManipulation.RemoveChilds(pathDestiny);
               
        currentPath = Instantiate(pathDefinition, new Vector3(0, 2, 0), Quaternion.identity);
        currentPath.transform.SetParent(pathDestiny);

        CharacterManager.Instance.InitCars(currentPath.InitialCharacterPosition);
        var characters = CharacterManager.Instance.Cars;       
    }     
}
