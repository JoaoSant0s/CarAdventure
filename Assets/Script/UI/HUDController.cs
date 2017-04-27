using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    [SerializeField]
    GameObject hudObject;
    [SerializeField]
    Text lifeText;

    string lifes = "{0}";

    void Awake() {
        UIController.OnActiveHUDScreen += ActiveHUD;
        Car.OnUpdateHUD += UpdateLife;
    }

    void UpdateLife(float number) {
        lifeText.text = string.Format(lifes, number);
    }

    void ActiveHUD(bool active) {
        hudObject.SetActive(active);
    }
    
}
