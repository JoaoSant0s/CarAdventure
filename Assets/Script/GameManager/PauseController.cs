using UnityEngine;

namespace CarAdventure.Controller {
    public class PauseController : MonoBehaviour {

        public delegate void TutorialClose();
        public static event TutorialClose OnTutorialClose;

        [SerializeField]
        GameObject uiController;
        [SerializeField]
        GameObject gameObjectHud;

        bool paused;

        public bool IsPaused
        {
            get{return paused;}
        }

       static PauseController instance;


       public static PauseController Instance
       {
            get{return instance;}
       }

        void OnDestroy()
        {
            TutorialUIController.OnTutorialController -= UpdatePausePanel;
        }
        
        void Awake()
        {
            TutorialUIController.OnTutorialController += UpdatePausePanel;
            paused = false;
            instance = this;
        }

        void UpdatePausePanel(bool active)
        {
            uiController.gameObject.SetActive(active);
            gameObjectHud.gameObject.SetActive(active);
        }

        public void ButtonQuit() 
        {
            Application.Quit();
        }    

        public void ClosePause()
        {            
            paused = false;
            uiController.gameObject.SetActive(paused); 
            Cursor.visible = false;
            Time.timeScale = 1f;            
        }                

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P)){ 
            	paused = !paused;
                uiController.gameObject.SetActive(paused);            	

            	if(paused){
            		Cursor.visible = true;
            		Time.timeScale = 0f;
        		}else{                    
                    if(OnTutorialClose != null) OnTutorialClose();
                    gameObjectHud.gameObject.SetActive(true);
					Cursor.visible = false;
					Time.timeScale = 1f;
        		}            	
            }
        }                

    }
}