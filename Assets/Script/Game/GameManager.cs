using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Transform spawnPosition;
    [SerializeField]
    Car carPrefab;
    [SerializeField]
    Claw clawPrefab;

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
