using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIController : MonoBehaviour {

    [SerializeField]
    Text label;
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
