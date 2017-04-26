using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [SerializeField]
    GameObject menuObject;
    	
    void Awake() {
        UIController.OnActiveMenuScreen += ActiveMenu;
    }

    void ActiveMenu(bool active) {        
        menuObject.SetActive(active);
    }

    public void StartGame() {        
        menuObject.SetActive(false);
        UIController.Instance.HUDState();
    }    

    public void OpenControls() {

    }
}
