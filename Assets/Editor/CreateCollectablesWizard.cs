using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCollectablesWizard : ScriptableWizard {       

    [Header("Add Collectables")]
    [SerializeField]
    Collectable.CollectableType type;
    [SerializeField]
    int numberNewCollectables;

    private static Transform collectableContent;
    private static PathController currentPath;
    private string path = "Assets/Prefab/";
    private string description = "Total de coletáveis ";   

    private static int totalCollectable;

    [MenuItem("Tools/Create Collectable")]
    static void CreateWizard() {
        currentPath = FindObjectOfType<PathController>();               
        collectableContent = currentPath.CollectableContent().transform;
        totalCollectable = collectableContent.childCount;        

        DisplayWizard<CreateCollectablesWizard>("Create Collectable", "Create Collectables", "Delete Collectable");             
    }

    void OnWizardUpdate() {
        currentPath.UpdateTotalCollectables(totalCollectable);
        helpString = description + totalCollectable;
    }

    void OnWizardCreate() {
        var finalPath = path + type.ToString() + ".prefab";

        var collectablePrefab = AssetDatabase.LoadAssetAtPath(finalPath, typeof(Collectable)) as Collectable;
        
        for (int i = 0; i < numberNewCollectables; i++) {
            var newCollectable = Instantiate(collectablePrefab, Vector3.zero, Quaternion.identity);
            newCollectable.transform.SetParent(collectableContent);
        }

        totalCollectable += numberNewCollectables;        
        OnWizardUpdate();
    }

    void OnWizardOtherButton() {
        var selectedTransform = Selection.activeTransform;
        
        if (selectedTransform == null) return;
      
        if (selectedTransform.GetComponent<Collectable>() != null) {             
            DestroyImmediate(selectedTransform.gameObject);
            totalCollectable += -1;            
        }
        
        OnWizardUpdate();
    }
}
