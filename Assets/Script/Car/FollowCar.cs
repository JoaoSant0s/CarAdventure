using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour {

    [SerializeField]
    Car currentCar;

    Vector3 offset;	
	void Awake () {
        offset = currentCar.transform.position - transform.position;
	}

    bool CheckCar() {
        if (currentCar == null) {
            currentCar = FindObjectOfType<Car>();
        }
        return currentCar == null;
    }

    void FixedUpdate() {
        if (CheckCar()) return;

        var newPosition = currentCar.transform.position + offset;
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
	
}
