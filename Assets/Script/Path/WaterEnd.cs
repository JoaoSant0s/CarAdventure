using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnd : MonoBehaviour {

    [SerializeField]
    float timeToDestroy = 3f;

    bool destroyObject;

    void Start() {
        destroyObject = false;
    }

    void OnTriggerEnter(Collider collider) {
        var character = collider.gameObject.GetComponentInParent<Car>();        

        if (character == null || destroyObject) return;
        destroyObject = true;

        StartCoroutine(DestroyCar(character.gameObject));
    }

    IEnumerator DestroyCar(GameObject ob) {
        yield return new WaitForSeconds(timeToDestroy);
        DestroyObject(ob);
    }

}
