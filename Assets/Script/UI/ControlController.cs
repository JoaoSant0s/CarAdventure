
using UnityEngine;

namespace CarAdventure.Controller.UI {

    public class ControlController : MonoBehaviour {

        [SerializeField]
        GameObject controlObject;
        
        void Awake() {
            PauseController.OnActiveControlPopup += ActiveControl;
            MenuController.OnActiveControlPopup += ActiveControl;
        }

        void ActiveControl() {
            controlObject.SetActive(true);
        }

        public void CloseScreen() {
            controlObject.SetActive(false);
        }

    }
}