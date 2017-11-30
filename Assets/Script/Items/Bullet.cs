using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAdventure.Entity.Component
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        float attack;
        [SerializeField]
        float destroyDelay;

        bool disabled;

        void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(DestroyCoroutine());

            if (disabled) return;
            var enemy = collision.transform.GetComponent<AttackEnemy>();

            if (enemy == null) return;
            if (enemy.Dying) return;

            disabled = true;
            
            enemy.ReduceLife(attack);
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(destroyDelay);
            DestroyObject(gameObject);
        }
    }
}