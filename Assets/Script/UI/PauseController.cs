
using UnityEngine;

namespace CarAdventure.Controller.UI {
    public class PauseController : MonoBehaviour {

        public delegate void ActiveControlPopup();
        public static event ActiveControlPopup OnActiveControlPopup;

        [SerializeField]
        GameObject pauseObject;

        void Awake() {
            UIController.OnActivePauseScreen += ActivePause;
        }

        void ActivePause(bool active) {
            pauseObject.SetActive(active);
        }

        public void QuitButton() {
            Application.Quit();
        }

        public void OpenControls() {
            if (OnActiveControlPopup != null)
                OnActiveControlPopup();
        }

    }
}