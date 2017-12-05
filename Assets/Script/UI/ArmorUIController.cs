using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUIController : MonoBehaviour {

	[SerializeField]
    Text label;
    [SerializeField]
    string baseLabelFormation;
    [SerializeField]
    Transform baseUIElement;
	// Use this for initialization
	void Awake () 
	{
		/*Car.OnShowArmor += InitArmor;
		ClawItems.OnUpdateArmor += UpdateArmorText;       
        GameManager.OnRestartUI += CloseArmor;*/
    }

    void OnDestroy()
    {
    	/*Car.OnShowArmor -= InitArmor;
    	ClawItems.OnUpdateArmor += UpdateArmorText;
        GameManager.OnRestartUI -= CloseArmor;*/
    }

    void InitArmor(float initLife)
    {
        baseUIElement.gameObject.SetActive(true);
        UpdateText(initLife);
    }

    void CloseArmor()
    {
        baseUIElement.gameObject.SetActive(false);        
    }

    void UpdateText(float currentLife)
    {
        label.text = string.Format(baseLabelFormation, currentLife);
    }
}
