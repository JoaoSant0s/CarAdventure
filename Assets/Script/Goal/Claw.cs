using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    [SerializeField]
    Transform clawPoint;

    [SerializeField]
    float sphereRadius = 10;

    bool usingClaw;
    bool goalCapured;
    SphereCollider sphereCollider;

    void Awake() {
        usingClaw = false;
        goalCapured = false;
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider collider) {              

        if(!usingClaw) UsingClaw(collider);

        if (usingClaw && !goalCapured) CaptureGoal(collider);
        
    }

    void CaptureGoal(Collider collider) {
        var goal = collider.gameObject.GetComponentInParent<Goal>();
        if (goal == null) return;

        goal.transform.SetParent(clawPoint.transform);
        goal.transform.localPosition = Vector3.zero;
        goalCapured = true;
    }

    void UsingClaw(Collider collider) {
        var character = collider.gameObject.GetComponentInParent<Car>();
        if (character == null) return;

        transform.SetParent(character.transform);
        transform.localPosition = new Vector3(0.1f, 0f, 0f);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        usingClaw = true;
        sphereCollider.radius = sphereRadius;
    }

}
    
