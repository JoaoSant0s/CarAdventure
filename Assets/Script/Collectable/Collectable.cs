using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public delegate void CheckCollectable(Transform agent);
    public static event CheckCollectable OnCheckCollectable;

    public enum CollectableType {
        GoldCollectable
    }

    
    [SerializeField]
    CollectableType type;
           
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

        StartCoroutine(StartAnimation(character.transform));        
    }

    IEnumerator StartAnimation(Transform agent) {
        animationCollected.enabled = true;

        do {
            yield return null;
        } while (animationCollected.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9);
                      
        if (OnCheckCollectable != null) OnCheckCollectable(agent);

        animationCollected.enabled = false;
        DestroyObject(gameObject);        
    }
  
}
