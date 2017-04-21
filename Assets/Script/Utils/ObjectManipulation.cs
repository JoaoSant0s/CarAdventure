using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectManipulation {

    public static void RemoveChilds(Transform parent) {
        for (int i = 0; i < parent.childCount; i++) {
            GameObject.DestroyObject(parent.GetChild(i).gameObject);
        }
    }

    public static Vector3 ForwardNormalized(Vector3 startPoint, Vector3 target) {
        return (target - startPoint).normalized;
    }

}
