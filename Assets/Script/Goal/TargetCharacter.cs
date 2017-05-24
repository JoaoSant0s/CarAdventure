
using UnityEngine;
using CarAdventure.Entity;

namespace CarAdventure.Entity.Component { 

    public class TargetCharacter : MonoBehaviour {

        public delegate void CheckTarget(Vector3 targetDestiny, bool attack);
        public static event CheckTarget OnCheckTarget;

        private string targetTag = "Player";   

        void OnTriggerStay(Collider collider){
            var character = collider.gameObject.GetComponentInParent<Car>();                
            if (character == null) return;

            if (OnCheckTarget != null) OnCheckTarget(character.transform.position, true);
        }

        void OnTriggerExit(Collider collider) {
            var character = collider.gameObject.GetComponentInParent<Car>();
            if (character == null) return;

            if (OnCheckTarget != null) OnCheckTarget(character.transform.position, false);
        }
    }

}