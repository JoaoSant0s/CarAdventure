using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level{

    [SerializeField]
    PathController pathDefinition;

    [SerializeField]
    List<CollectableMap> currentCollectables;

    public PathController PathDefinition() {
        return pathDefinition;
    }

    public List<CollectableMap> CurrentCollectables() {
        return currentCollectables;
    }

    [System.Serializable]
    public class CollectableMap {
        [SerializeField]
        Collectable collectablePrefab;

        [SerializeField]
        int collectableCount;

        public Collectable CollectablePrefab() {
            return collectablePrefab;
        }

        public int CollectableCount() {
            return collectableCount;
        }

    }
}
