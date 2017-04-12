using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {            

    PathController currentPath;
    Dictionary<Car, List<SavePoint>> characterSavePoinst;

    private static PathManager instance;
    public static PathManager Instance {
        get { return instance; }
    }    

    void Awake() {
        instance = this;
        SavePath.OnSavePoint += SavePoint;

        characterSavePoinst = new Dictionary<Car, List<SavePoint>>();
    }

    void OnDestroy() {
        SavePath.OnSavePoint -= SavePoint;
    }

    internal void LoadPath(PathController pathDefinition) {
        currentPath = Instantiate(pathDefinition, new Vector3(0, 2, 0), new Quaternion(0, 1, 0, 1));

        CharacterManager.Instance.InitCars(currentPath.InitialCharacterPosition);
        var characters = CharacterManager.Instance.Cars;

        foreach (var character in characters) {
            characterSavePoinst[character] = new List<SavePoint>(currentPath.SavePoints);
        }

    }    

    void SavePoint(Car character, int id, bool verify) {        
        var savePoint = characterSavePoinst[character].Find(x => x.Index == id);
        if (savePoint == null) return;
                                                
        savePoint.Verify = verify;        
    }

    bool CheckCharacterCompleteTurn(Car character) {
        var points = characterSavePoinst[character];

        return points.FindAll(x => x.Verify == false).Count == 0;
    }


}
