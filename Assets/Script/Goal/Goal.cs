using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {   
     
    bool active;    

    Vector3 startPosition;
    Transform startParent;
    Vector3 startScale = new Vector3(10f, 10f, 10f);

    void Awake() {
        active = false;     
    }

    void Start() {
        startPosition = transform.position;
        startScale = transform.localScale;
        startParent = transform.parent;
    }    

	internal bool Active {
        get { return active; }
        set { active = value; }
    }

    internal void Reset() {
        transform.SetParent(startParent);
        transform.localScale = startScale;
        transform.position = startPosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
