using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CarAdventure.Entity;
using CarAdventure.Controller.Manager;
using TMPro;

public class LifeUIController : MonoBehaviour {
	[SerializeField]
    TextMeshProUGUI label;    
    [SerializeField]
    string baseLabelFormation;
    [SerializeField]
    Transform baseUIElement;
	// Use this for initialization
	void Awake () {		
        Car.OnDamageLife += UpdateText;
        Car.OnShowLife += InitLife;
        GameManager.OnRestartUI += CloseLife;
    }

    void OnDestroy()
    {
        Car.OnDamageLife -= UpdateText;
        Car.OnShowLife -= InitLife;
        GameManager.OnRestartUI -= CloseLife;
    }

    void InitLife(float initLife)
    {
        baseUIElement.gameObject.SetActive(true);
        UpdateText(initLife);
    }

    void CloseLife()
    {
        baseUIElement.gameObject.SetActive(false);        
    }

    void UpdateText(float currentLife)
    {
        label.text = string.Format(baseLabelFormation, currentLife);
    }	
}
