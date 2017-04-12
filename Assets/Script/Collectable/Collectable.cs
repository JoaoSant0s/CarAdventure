using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    Transform portalSpawn;

    bool destroyed;

    Animator animationCollected;
    void Awake() {
        destroyed = false;
        animationCollected = GetComponent<Animator>();
        animationCollected.enabled = false;
    }

    void OnTriggerEnter(Collider collider) {

        var character = collider.gameObject.GetComponentInParent<Car>();
        if (character == null || destroyed) return;
        destroyed = true;

        StartCoroutine(StartAnimation());
        //(character.transform);
    }

    IEnumerator StartAnimation() {
        animationCollected.enabled = true;

        do {
            yield return null;
        } while (animationCollected.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 || animationCollected.IsInTransition(0));
               
        DestroyObject(gameObject);

    }

    void SpawnBlock(Transform character) {
        //character.position;
        //character.forward;
        Debug.Log(character.forward);
        Instantiate(portalSpawn, transform.position + character.forward * 20, Quaternion.identity);        
    }

}
