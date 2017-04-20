using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    [SerializeField]
    Transform initialCharacterPosition;    
    [SerializeField]
    GameObject collectablesParent;

    private int totalCollectables;

    public GameObject CollectableContent() {
        return collectablesParent;
    }

    void Awake() {       
        UpdateTotalCollectables(collectablesParent.transform.childCount);        
    }

    public Vector3 InitialCharacterPosition {
        get { return initialCharacterPosition.position; }
    } 
            
    public void UpdateTotalCollectables(int number) {
        totalCollectables = number;
    } 

    //Editor, not in game;
    internal void AddingCollectables(int number) {
        totalCollectables += number;
    }

    internal void RemoveCollectables() {
        totalCollectables -= 1;
    }

}
