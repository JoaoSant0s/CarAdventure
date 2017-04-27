using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {
    public delegate void CatchClaw();
    public static event CatchClaw OnCatchClaw;

    [SerializeField]
    Transform clawPoint;
        
    [SerializeField]
    Vector3 sizeGetGoal;

    bool usingClaw;
    bool goalCapured;
    Goal currentGoal;
    BoxCollider boxCollider;

    void Awake() {
        usingClaw = false;
        goalCapured = false;
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider collider) {              
        if(!usingClaw) UsingClaw(collider);
        if (usingClaw && !goalCapured) CaptureGoal(collider);        
    }

    public Goal ReleaseGoal() {
        if (!goalCapured) return null;
        
        goalCapured = false;
        
        return currentGoal;
    }

    void CaptureGoal(Collider collider) {
        currentGoal = collider.gameObject.GetComponent<Goal>();
                
        if (currentGoal == null) return;
        if (currentGoal.Active) return;

        currentGoal.transform.SetParent(clawPoint.transform);
        currentGoal.transform.localScale = new Vector3(3f, 3f, 3f);
        currentGoal.transform.localPosition = Vector3.zero;
        goalCapured = true;
    }

    void UsingClaw(Collider collider) {
        var character = collider.gameObject.GetComponentInParent<Car>();
        if (character == null) return;

        SetCarClaw(character);       

        if (OnCatchClaw != null) OnCatchClaw();
    }

    internal void ResetGoal() {
        if (currentGoal == null) return;
        currentGoal.Reset();
        goalCapured = false;
    }

    internal void SetCarClaw(Car character) {
        usingClaw = true;
        character.Claw = this;
        transform.SetParent(character.transform);
        transform.localPosition = new Vector3(0.1f, 0f, 0f);
        transform.rotation = new Quaternion(0, 0, 0, 0);        
        boxCollider.size = sizeGetGoal;
    }

}
    
