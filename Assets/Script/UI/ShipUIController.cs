using UnityEngine;
using UnityEngine.UI;
using CarAdventure.Controller;
using TMPro;

public class ShipUIController : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI label; 
    [SerializeField]
    string baseLabelFormation;
	// Use this for initialization
	void Awake () {
        ShipController.OnReduceShipLife += UpdateText;
    }

    void OnDestroy()
    {
        ShipController.OnReduceShipLife -= UpdateText;
    }

    void UpdateText(float currentLife, float startLife)
    {
        label.text = string.Format(baseLabelFormation, currentLife, startLife);
    }
}
