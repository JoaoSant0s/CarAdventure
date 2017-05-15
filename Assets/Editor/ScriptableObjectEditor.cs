using System.Collections;		
 using System.Collections.Generic;		
 using UnityEngine;		
 		
 public class ScriptableObjectEditor : ScriptableObject {		
 		
     #if UNITY_EDITOR		
 		
     public static class CreateScriptableObjectMenu {		
 		
        [UnityEditor.MenuItem("Tools/Create ScriptableObject/LevelCollection")]		
        public static void CreateAsset() {
            var ex = ScriptableObject.CreateInstance<ItemList>();
            UnityEditor.AssetDatabase.CreateAsset(ex, UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/Modules/ItemList.asset"));
        }		
     }		
 		
     #endif		
 }