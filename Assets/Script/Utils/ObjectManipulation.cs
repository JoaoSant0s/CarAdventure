using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectManipulation {

    public static void RemoveChilds(Transform parent) {
        for (int i = 0; i < parent.childCount; i++) {
            GameObject.DestroyObject(parent.GetChild(i).gameObject);
        }
    }

}
