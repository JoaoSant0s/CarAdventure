using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePath : MonoBehaviour {

    public delegate void SavePoint (Character character, int index, bool save);
    public static event SavePoint OnSavePoint;

    [SerializeField]
    int index;

    public int Index {
        get { return index; }
        set { index = value; }
    }

    void OnTriggerEnter(Collider collider) {        
        var character = collider.gameObject.GetComponentInParent<Character>();
        
        if (character == null) return;        

        if (OnSavePoint != null) OnSavePoint(character, index, false);        
    }

    void OnTriggerExit(Collider collider) {
        
        var character = collider.gameObject.GetComponentInParent<Character>();
        if (character == null) return;

        if (OnSavePoint != null) OnSavePoint(character, index, true);
    }

}
