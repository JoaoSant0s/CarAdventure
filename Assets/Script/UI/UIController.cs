using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public delegate void ActiveMenuScreen(bool active);
    public static event ActiveMenuScreen OnActiveMenuScreen;

    public delegate void ActiveEndtScreen(bool active);
    public static event ActiveEndtScreen OnActiveEndtScreen;

    public delegate void ActiveDeathScreen(bool active);
    public static event ActiveDeathScreen OnActiveDeathScreen;

    public delegate void ActivePauseScreen(bool active);
    public static event ActivePauseScreen OnActivePauseScreen;

    public delegate void ActiveHUDScreen(bool active);
    public static event ActiveHUDScreen OnActiveHUDScreen;    

    public enum UIState {
        menu,
        end,
        dead,
        pause,
        hud
    }

    private UIState uiState;
    private static UIController instance;

    void Start() {
        instance = this;
        uiState = UIState.menu;
        Time.timeScale = 0f;
        DefyingScreen();
    }   

    public static UIController Instance {
        get { return instance; }
    }

    public void DeadState() {
        uiState = UIState.dead;
        Time.timeScale = 0f;
        DefyingScreen();
    }

    public void HUDState() {
        uiState = UIState.hud;
        Time.timeScale = 1f;
        DefyingScreen();
    }

    void DefyingScreen() {

        if (OnActiveMenuScreen != null) OnActiveMenuScreen(uiState == UIState.menu);
        if (OnActivePauseScreen != null) OnActivePauseScreen(uiState == UIState.pause);
        if (OnActiveHUDScreen != null) OnActiveHUDScreen(uiState == UIState.hud);

        if (OnActiveEndtScreen != null) OnActiveEndtScreen(uiState == UIState.end);
        if (OnActiveDeathScreen != null) OnActiveDeathScreen(uiState == UIState.dead);

    }

    void Update () {
        if (Input.GetButtonDown("Pause")) {

            if(uiState == UIState.pause) {
                Time.timeScale = 1f;
                uiState = UIState.hud;
            } else {
                Time.timeScale = 0f;
                uiState = UIState.pause;
            }            
            
            DefyingScreen();
        }	
	}
}
