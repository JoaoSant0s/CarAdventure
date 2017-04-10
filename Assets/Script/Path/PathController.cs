using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour {

    [SerializeField]
    List<Transform> initialCharacterPosition;

    [SerializeField]
    List<SavePath> savePaths;


    void Awake() {
        for (int i = 0; i < savePaths.Count; i++) {
            savePaths[i].Index = i;
        }
    }

    public List<Vector3> InitialCharacterPosition {
        get {
            var positionList = initialCharacterPosition.ConvertAll<Vector3>(x => x.position);
            return positionList;
        }
    } 
    
    public List<SavePoint> SavePoints {
        get {
            var savePointList = savePaths.ConvertAll<SavePoint>(x => new SavePoint(x.Index));
            return savePointList;
        }
    } 
     


}
