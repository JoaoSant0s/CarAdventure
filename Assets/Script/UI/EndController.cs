using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour {

    public delegate float FinalTime();
    public static event FinalTime OnFinalTime;

    public delegate float NumberDeads();
    public static event NumberDeads OnNumberDeads;

    [SerializeField]
    GameObject endObject;

    [SerializeField]
    Text lifeTime;
    [SerializeField]
    Text deathsNumbers;

    string lifeText = "Tempo de vida: {0} min";
    string deathsText = "Número de mortes: {0}";

    void Awake() {
       UIController.OnActiveEndtScreen += ActiveEnd;
    }

    void ActiveEnd(bool active) {
        if (OnFinalTime != null) {
            lifeTime.text = string.Format(lifeText, (int) OnFinalTime());
        }

        if (OnNumberDeads != null) {
            deathsNumbers.text = string.Format(deathsText, OnNumberDeads());            
        }        

        endObject.SetActive(active);
    }

    public void ButtonQuit() {
        Application.Quit();
    }

}
