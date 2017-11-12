
using UnityEngine;

namespace CarAdventure.Controller.UI {
    public class DeathController : MonoBehaviour {

        public delegate void SpawnCar();
        public static event SpawnCar OnSpawnCar;

        public delegate void UpdateGameState();
        public static event UpdateGameState OnUpdateGameState;

        [SerializeField]
        GameObject deathObject;

        void Awake() {
            UIController.OnActiveDeathScreen += ActiveDeath;
        }

        void ActiveDeath(bool active) {
            deathObject.SetActive(active);
        }

        public void RestartButton() {
            if (OnSpawnCar != null)
                OnSpawnCar();
            if (OnUpdateGameState != null)
                OnUpdateGameState();
            UIController.Instance.HUDState();
        }
        
    }
}