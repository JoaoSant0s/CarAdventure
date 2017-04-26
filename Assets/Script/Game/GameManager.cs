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
    bool haveClaw;         

    void Awake() {
        numberDeads = 0;
        Car.OnDestroyCar += Died;
        DeathController.OnSpawnCar += SpawnCar;
        Claw.OnCatchClaw += UsingClaw;
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

    void UsingClaw() {
        haveClaw = true;
    }

    void SpawnCar() {        

        var currentCar = Instantiate(carPrefab, spawnPosition.position, Quaternion.identity);
        
        if (haveClaw) {
            var currentClaw = Instantiate(clawPrefab);
            currentClaw.SetCarClaw(currentCar);
        }            

        currentCar.transform.SetParent(spawnPosition.parent);
    }


  
}
