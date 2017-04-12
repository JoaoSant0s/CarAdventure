using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollection : ScriptableObject {
    [SerializeField]
    Level[] levels;

    public Level[] Levels {
        get { return levels; }
    }

    #if UNITY_EDITOR

    public static class CreateScriptableObjectMenu {

        [UnityEditor.MenuItem("Tools/Create ScriptableObject/LevelCollection")]
        public static void CreateAsset() {
            var ex = ScriptableObject.CreateInstance<LevelCollection>();
            UnityEditor.AssetDatabase.CreateAsset(ex, UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/Modules/Levels/LevelCollection.asset"));
        }
    }

    #endif
}
