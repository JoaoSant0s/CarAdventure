
using UnityEngine;
using CarAdventure.Entity.Component;

 public class ScriptableObjectEditor : ScriptableObject {		
 		
     #if UNITY_EDITOR		
 		
     public static class CreateScriptableObjectMenu {		
 		
        [UnityEditor.MenuItem("Tools/Create ScriptableObject/Level Collection")]		
        public static void CreateLevelCollection() {
            var ex = ScriptableObject.CreateInstance<ItemList>();
            UnityEditor.AssetDatabase.CreateAsset(ex, UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/Modules/ItemList.asset"));
        }

        [UnityEditor.MenuItem("Tools/Create ScriptableObject/Dialogs Module")]
        public static void CreateDialogsModule() {
            var ex = ScriptableObject.CreateInstance<DialogsModule>();
            UnityEditor.AssetDatabase.CreateAsset(ex, UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/Modules/DialogsModule.asset"));
        }
    }		
 		
     #endif		
 }