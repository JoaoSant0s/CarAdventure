
using UnityEngine;

namespace CarAdventure.Common {
    public static class ObjectManipulation {
        
        public static void RemoveChilds(Transform parent) {
            for (int i = 0; i < parent.childCount; i++) {
                GameObject.DestroyObject(parent.GetChild(i).gameObject);                                    
            }
        }

        public static Vector3 ForwardNormalized(Vector3 startPoint, Vector3 target) {
            return (vectorYzero(target) - vectorYzero(startPoint)).normalized;
        }

        private static Vector3 vectorYzero(Vector3 vector){
            return new Vector3(vector.x, vector.y, vector.z);
        }        
    }
}
