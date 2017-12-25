using UnityEngine;

namespace CarAdventure.Controller {
    public class PauseController : MonoBehaviour {

        [SerializeField]
        PauseUIController uiController;

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

        void Awake()
        {
            paused = false;
            instance = this;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P)){ 
            	paused = !uiController.gameObject.activeSelf;
            	uiController.gameObject.SetActive(paused);

            	if(paused){
            		Cursor.visible = true;
            		Time.timeScale = 0f;
        		}else{
					Cursor.visible = false;
					Time.timeScale = 1f;
        		}

            	
            }
        }                

    }
}