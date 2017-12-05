using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAdventure.Entity.Component
{
	public class FixedArmor : MonoBehaviour {

		public delegate void RemoveArmor();
        public static event RemoveArmor OnRemoveArmor;

		[SerializeField]
		float maxLifeTime;

		void Start()
        {
            StartCoroutine(DestroyEffect());
        }    

        IEnumerator DestroyEffect()
        {            
        	yield return new WaitForSeconds(maxLifeTime);
        	if(OnRemoveArmor != null) OnRemoveArmor();

        	DestroyObject(gameObject);
        }
	}
}
