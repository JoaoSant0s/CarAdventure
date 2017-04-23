using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {   
     
    bool active;
    bool goalInTarget;

    void Awake() {
        active = false;
        goalInTarget = false;
    }

    internal bool GoalInTarget {
        get { return goalInTarget; }
        set { goalInTarget = value; }
    }

	internal bool Active {
        get { return active; }
        set { active = value; }
    }

}
