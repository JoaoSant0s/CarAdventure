using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    [SerializeField]
    GameObject pauseObject;

    void Awake() {
        UIController.OnActivePauseScreen += ActivePause;
    }

    void ActivePause(bool active) {
        pauseObject.SetActive(active);
    }
    
}
