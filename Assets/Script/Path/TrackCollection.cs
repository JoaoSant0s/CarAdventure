using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollection : ScriptableObject {

    [SerializeField]
    PathController[] paths;
    
    public PathController[] Paths {
        get { return paths; }
    }

    #if UNITY_EDITOR

        public static class CreateScriptableObjectMenu{
                            
        [UnityEditor.MenuItem("Tools/Create ScriptableObject/TrackCollection")]
            public static void CreateAsset() {
                var ex = ScriptableObject.CreateInstance<TrackCollection>();
                UnityEditor.AssetDatabase.CreateAsset(ex, UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/Modules/Tracks/TrackCollection.asset"));                
            }
        }

    #endif
}
