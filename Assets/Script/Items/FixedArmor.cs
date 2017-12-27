using System.Collections;
using UnityEngine;

namespace CarAdventure.Entity.Component
{
	public class FixedArmor : MonoBehaviour {

        public delegate void RemoveArmor();
        public static event RemoveArmor OnRemoveArmor;

        [SerializeField]
        float redutorLife;
        [SerializeField]
        float cooldownRedutor;
		[SerializeField]
		float maxLifeTime;

        float lastAttackTime;

		void Start()
        {
            lastAttackTime = 0f;
            StartCoroutine(DestroyEffect());
        }    

        IEnumerator DestroyEffect()
        {            
        	yield return new WaitForSeconds(maxLifeTime);
        	if(OnRemoveArmor != null) OnRemoveArmor();

        	DestroyObject(gameObject);
        }

        void OnTriggerStay(Collider collider)
        {        
            var enemy = collider.GetComponentInParent<AttackEnemy>();
            if(enemy == null) return;

            if (lastAttackTime >= Time.timeSinceLevelLoad) return;
            lastAttackTime = Time.timeSinceLevelLoad + cooldownRedutor;

            enemy.ReduceScaleLife(redutorLife);                                
        }    
	}
}
