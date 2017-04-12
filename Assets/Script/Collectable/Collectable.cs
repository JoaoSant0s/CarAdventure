using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    Animator animationCollected;
    void Awake() {
        
        animationCollected = GetComponent<Animator>();
        animationCollected.enabled = false;
    }
    void OnTriggerEnter(Collider collider) {

        var character = collider.gameObject.GetComponentInParent<Character>();
        if (character == null) return;
                
        StartCoroutine(StartAnimation());              
    }
    IEnumerator StartAnimation() {
        animationCollected.enabled = true;

        do {
            yield return null;
        } while (animationCollected.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 || animationCollected.IsInTransition(0));

        DestroyObject(gameObject);
    }





}
