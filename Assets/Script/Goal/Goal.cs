using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {    
    bool active;

    void Awake() {
        active = false;
    }

	internal bool Active {
        get { return active; }
        set { active = value; }
    }

}
