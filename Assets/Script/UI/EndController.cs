using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

    [SerializeField]
    GameObject endObject;

    void Awake() {
       UIController.OnActiveEndtScreen += ActiveEnd;
    }
    void ActiveEnd(bool active) {
        endObject.SetActive(active);
    }


}
