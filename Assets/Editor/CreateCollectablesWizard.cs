using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCollectablesWizard : ScriptableWizard {    

    [SerializeField]
    Collectable.CollectableType type;

    [SerializeField]
    List<Vector3> positionsCollectables;


    private static Transform collectableContent;
    private string path = "Assets/Prefab/";    

    [MenuItem("Tools/Create Collectable")]
    static void CreateWizard() {
        collectableContent = GameObject.FindGameObjectWithTag("CollectableContent").transform;
        DisplayWizard<CreateCollectablesWizard>("Create Collectable", "Create");
    }

    void OnWizardCreate() {
        var finalPath = path + type.ToString() + ".prefab";

        var collectablePrefab = AssetDatabase.LoadAssetAtPath(finalPath, typeof(Collectable)) as Collectable;

        foreach (var position in positionsCollectables) {
            var newCollectable = Instantiate(collectablePrefab, position, Quaternion.identity);
            newCollectable.transform.SetParent(collectableContent);
        }
        
    }
}
