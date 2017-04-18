using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    int currentLevelIndex;
    [SerializeField]
    LevelCollection levelCollection;

    [SerializeField]
    Transform portalSpawn;

    Level currentLevel;

    void Awake() {
        instance = this;
        Collectable.OnCheckCollectable += FinishGoal;
    }

    void OnDestroy() {
        Collectable.OnCheckCollectable -= FinishGoal;
    }

    private static LevelManager instance;
    public static LevelManager Instance {
        get { return instance; }
    }

    internal void NextLevel() {
        currentLevel =  levelCollection.Levels[currentLevelIndex];        

        PathManager.Instance.LoadPath(currentLevel.PathDefinition());        
    }

    void FinishGoal(Transform character) {
        var pathController = currentLevel.PathDefinition();
        if (!pathController.IsEmptyCollectables()) return;
        Instantiate(portalSpawn, transform.position + character.forward * 20, Quaternion.identity);
    }    

}
