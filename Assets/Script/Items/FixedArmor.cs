using System.Collections;
using UnityEngine;

namespace CarAdventure.Entity.Component
{
	public class FixedArmor : MonoBehaviour {

        [SerializeField]
        float redutorLife;
        [SerializeField]
        float cooldownRedutor;

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

        void OnTriggerEnter(Collider collider)
        {        
            var enemy = collider.GetComponentInParent<AttackEnemy>();
            if(enemy != null)
            {
                StartCoroutine("StartDamageCoroutine", enemy);
            }
        }

        IEnumerator StartDamageCoroutine(AttackEnemy enemy)
        {   
            yield return new WaitForSeconds(cooldownRedutor);         
            enemy.ReduceScaleLife(redutorLife);
            yield return new WaitForSeconds(cooldownRedutor);         
            enemy.ReduceScaleLife(redutorLife);
            yield return new WaitForSeconds(cooldownRedutor);
            enemy.ReduceScaleLife(redutorLife);
            yield return new WaitForSeconds(cooldownRedutor);
        }                
	}
}
