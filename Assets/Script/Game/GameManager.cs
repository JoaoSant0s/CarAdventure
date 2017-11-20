
using UnityEngine;
using CarAdventure.Entity;
using CarAdventure.Entity.Component;
using CarAdventure.Controller.UI;

namespace CarAdventure.Manager { 
    public class GameManager : MonoBehaviour {
        
        [SerializeField]
        Transform spawnPosition;
        [SerializeField]
        Car carPrefab;
        [SerializeField]
        ClawCamera clawPrefab;
        
        int numberDeads;           

        void Awake() {
            numberDeads = 0;
            Car.OnDestroyCar += Died;
            DeathController.OnSpawnCar += SpawnCar;        
            EndController.OnNumberDeads += NumberDeads;
            EndController.OnFinalTime += FinalTime;
        }
    
        float FinalTime() {
            return Time.timeSinceLevelLoad / 60;
        }

        float NumberDeads() {
            return numberDeads;
        }

        void Died() {
            numberDeads++;
        }   

        void SpawnCar() {        

            var currentCar = Instantiate(carPrefab, spawnPosition.position, Quaternion.identity);               

            currentCar.transform.SetParent(spawnPosition.parent);
        } 
    }

}