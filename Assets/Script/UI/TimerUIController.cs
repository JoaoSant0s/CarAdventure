using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CarAdventure.Controller.Manager;

public class TimerUIController : MonoBehaviour {

    [SerializeField]
    Text label;
    [SerializeField]
    string baseLabelFormation;
    
    void Awake () {
        SpawnController.OnHorderTimeCounter += UpdateText;
    }

    void OnDestroy()
    {
        SpawnController.OnHorderTimeCounter -= UpdateText;
    }

    void UpdateText(int currentTime)
    {        
        label.text = string.Format(baseLabelFormation, currentTime);
    }

}
