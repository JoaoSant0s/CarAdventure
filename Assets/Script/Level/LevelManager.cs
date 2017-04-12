using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    int currentLevelIndex;
    [SerializeField]
    LevelCollection levelCollection;

    Level currentLevel;

    void Awake() {
        instance = this;
    }

    private static LevelManager instance;
    public static LevelManager Instance {
        get { return instance; }
    }

    internal void NextLevel() {
        currentLevel =  levelCollection.Levels[currentLevelIndex];
        PathManager.Instance.LoadPath(currentLevel.PathDefinition());

        //HERE, Load others datas of current level, with collectables;
    }
}
