using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CarAdventure.Entity.Component;
using CarAdventure.Controller.Manager;
using TMPro;

public class ArmorUIController : MonoBehaviour {

	[SerializeField]
    TextMeshProUGUI label; 
    [SerializeField]
    string baseLabelFormation;
    [SerializeField]
    Transform baseUIElement;
	// Use this for initialization
	void Awake () 
	{
		ClawItems.OnShowArmor += InitArmor;
		ClawItems.OnUpdateArmor += UpdateArmorText;       
        GameManager.OnRestartUI += CloseArmor;
    }

    void OnDestroy()
    {
    	ClawItems.OnShowArmor -= InitArmor;
    	ClawItems.OnUpdateArmor -= UpdateArmorText;
        GameManager.OnRestartUI -= CloseArmor;
    }

    void InitArmor(float initCount)
    {    	
        baseUIElement.gameObject.SetActive(true);
        UpdateArmorText(initCount);
    }

    void CloseArmor()
    {
        baseUIElement.gameObject.SetActive(false);        
    }

    void UpdateArmorText(float currentCount)
    {
        label.text = string.Format(baseLabelFormation, currentCount);
    }
}
