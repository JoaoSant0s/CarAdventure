
using UnityEngine;

namespace CarAdventure.Controller.UI {
    public class MenuController : MonoBehaviour {

        public delegate void ActiveControlPopup();
        public static event ActiveControlPopup OnActiveControlPopup;

        [SerializeField]
        GameObject menuObject;

        void Awake() {
            UIController.OnActiveMenuScreen += ActiveMenu;
        }

        void ActiveMenu(bool active) {
            menuObject.SetActive(active);
        }

        public void StartGame() {
            menuObject.SetActive(false);
            UIController.Instance.HUDState();
        }

        public void OpenControls() {
            if (OnActiveControlPopup != null)
                OnActiveControlPopup();
        }
    }
}