using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    [SerializeField]
    List<Transform> initialCharacterPosition;    
    [SerializeField]
    GameObject collectablesParent;

    private int totalCollectables;

    public GameObject CollectableContent() {
        return collectablesParent;
    }

    void Awake() {       
        UpdateTotalCollectables(collectablesParent.transform.childCount);        
    }

    public List<Vector3> InitialCharacterPosition {
        get {
            var positionList = initialCharacterPosition.ConvertAll<Vector3>(x => x.position);
            return positionList;
        }
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
