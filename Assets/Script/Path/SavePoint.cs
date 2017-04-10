using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint {

    int index;
    bool verify;

    public SavePoint(int id) {
        index = id;
        verify = false;
    } 
    
    public int Index {
        get { return index; }
    }   


    public bool Verify {
        get { return verify; }
        set { verify = value; }
    }


}
