using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    [SerializeField]
    GameObject startScene;
    	
    void Awake() {
        Time.timeScale = 0f;
    }

    public void StartGame() {
        Time.timeScale = 1f;
        startScene.SetActive(false);
    }

    public void OpenConfigurations() {

    }

    public void OpenControls() {

    }
}
