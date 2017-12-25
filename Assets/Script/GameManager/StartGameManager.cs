using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour {	

	[SerializeField]
	GameObject loadScreen;	
	[SerializeField]
	GameObject startButton;
	[SerializeField]
	Slider slider;
	
	public void LoadGameScene()
	{		
		StartCoroutine(LoadAsyncCoroutine());		
	}

	IEnumerator LoadAsyncCoroutine()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync("scene1", LoadSceneMode.Single);		

		startButton.SetActive(false);
		loadScreen.SetActive(true);

		while(!operation.isDone)
		{			
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
