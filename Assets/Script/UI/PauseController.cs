using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public delegate void ActiveControlPopup();
    public static event ActiveControlPopup OnActiveControlPopup;

    [SerializeField]
    GameObject pauseObject;

    void Awake() {
        UIController.OnActivePauseScreen += ActivePause;
    }

    void ActivePause(bool active) {
        pauseObject.SetActive(active);
    }    

    public void QuitButton() {
        Application.Quit();
    }

    public void OpenControls() {
        if (OnActiveControlPopup != null) OnActiveControlPopup();
    }

}
