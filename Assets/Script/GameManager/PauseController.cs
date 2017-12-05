
using UnityEngine;

namespace CarAdventure.Controller {
    public class PauseController : MonoBehaviour {

        [SerializeField]
        PauseUIController uiController;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P)){ 
            	var nextState = !uiController.gameObject.active;
            	uiController.gameObject.SetActive(nextState);

            	if(nextState){
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