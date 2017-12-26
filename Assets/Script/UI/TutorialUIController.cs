using UnityEngine;
using CarAdventure.Controller;

public class TutorialUIController : MonoBehaviour {

	[SerializeField]
	GameObject popup;

	public delegate void TutorialController(bool active);
    public static event TutorialController OnTutorialController;

    void OnDestroy()
    {
        PauseController.OnTutorialClose -= CloseTutorial;
    }
    
    void Awake()
    {
        PauseController.OnTutorialClose += CloseTutorial;        
    }

    void CloseTutorial()
    {    	
    	popup.SetActive(false);
    }

	public void ClosePopup()
	{
		CloseTutorial();
		if(OnTutorialController != null) OnTutorialController(true);
	}

	public void OpenPopup()
	{
		popup.SetActive(true);
		if(OnTutorialController != null) OnTutorialController(false);
	}
}
