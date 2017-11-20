
using System.Collections;
using UnityEngine;
using CarAdventure.Entity;

namespace CarAdventure.Environment {
    
    public class WaterEnd : MonoBehaviour {

        [SerializeField]
        float timeToDestroy = 3f;

        bool destroyObject;

        void Start() {
            destroyObject = false;
        }

        void OnTriggerEnter(Collider collider) {
            var character = collider.gameObject.GetComponentInParent<Car>();        

            if (character == null || destroyObject) return;
            destroyObject = true;

            StartCoroutine(DestroyCar(character));
        }

        IEnumerator DestroyCar(Car car)
        {
            yield return new WaitForSeconds(timeToDestroy);
            car.Destroy();
        }

    }

}
