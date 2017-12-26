using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour {	

	[SerializeField]
	GameObject loadScreen;		
	[SerializeField]
	GameObject mainPanel;
	[SerializeField]
	Slider slider;

	void Awake () {
        TutorialUIController.OnTutorialController += UpdateMainPanel;
    }

    void OnDestroy()
    {
        TutorialUIController.OnTutorialController -= UpdateMainPanel;
    }

    void UpdateMainPanel(bool value)
    {
    	mainPanel.SetActive(value);   
    }
	
	public void LoadGameScene()
	{		
		StartCoroutine(LoadAsyncCoroutine());		
	}

	public void ButtonQuit() {
        Application.Quit();
    } 

	IEnumerator LoadAsyncCoroutine()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync("scene1", LoadSceneMode.Single);		

		mainPanel.SetActive(false);
		loadScreen.SetActive(true);

		while(!operation.isDone)
		{			
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
