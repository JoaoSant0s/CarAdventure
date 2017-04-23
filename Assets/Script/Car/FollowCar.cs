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

    void FixedUpdate() {
        var newPosition = currentCar.transform.position + offset;
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);

    }
	
}
