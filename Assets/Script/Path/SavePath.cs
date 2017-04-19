using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePath : MonoBehaviour {    

    [SerializeField]
    int index;

    public int Index {
        get { return index; }
        set { index = value; }
    }

    void OnTriggerEnter(Collider collider) {        
        var character = collider.gameObject.GetComponentInParent<Car>();
        
        if (character == null) return;                      
    }

    void OnTriggerExit(Collider collider) {
        
        var character = collider.gameObject.GetComponentInParent<Car>();
        if (character == null) return;        
    }

}
