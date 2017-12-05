using UnityEngine;
using UnityEngine.UI;
using CarAdventure.Controller.Manager;

public class TimerUIController : MonoBehaviour {

    [SerializeField]    
    Text label;
    [SerializeField]
    string baseLabelFormation;
    [SerializeField]
    Transform baseUIElement;
    
    void Awake () {
        SpawnController.OnHorderTimeCounter += UpdateText;
        GameManager.OnShowHorder += InitHorder;
        GameManager.OnRestartUI += CloseHorder;
    }

    void OnDestroy()
    {
        SpawnController.OnHorderTimeCounter -= UpdateText;
        GameManager.OnShowHorder -= InitHorder;
        GameManager.OnRestartUI -= CloseHorder;
    }

    void InitHorder()
    {
        baseUIElement.gameObject.SetActive(true);
    }

    void CloseHorder()
    {
        baseUIElement.gameObject.SetActive(false);
    }

    void UpdateText(int currentTime)
    {                    
        label.text = string.Format(baseLabelFormation, currentTime);
    }

}
