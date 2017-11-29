
using UnityEngine;
using CarAdventure.Common;
using CarAdventure.Controller.UI;
using System.Collections;
using CarAdventure.Entity.Component;

namespace CarAdventure.Entity { 

    public class AttackEnemy : Enemy {

        public delegate void NextHorder(EnemyMotor motor);
        public static event NextHorder OnNextHorder;

        float lastAttackTime;
        bool attacking;
        bool dying;
        Animator animator;

        public bool Dying {
            get { return dying; }
        }

        void Awake()
        {            
            //DeathController.OnUpdateGameState += ResetState;

            lastAttackTime = 0f;
            animator = GetComponent<Animator>();            
        }        

        internal void CheckTarget(Vector3 targetDestiny, bool moveToTarget)
        {
            //Debug.Log(attacking + " "  + dying);
            if (attacking || dying) return;            
            Motor.Move(targetDestiny, () => { animator.SetTrigger("walking"); return true; });
        }        

        internal void NotAttack()
        {            
            attacking = false;
        }

        internal void Attack(Car car)
        {
            if (dying) return;
            AttackingTime(car.transform.position, () => { car.ReduceLife(attack); StartCoroutine(IdleCoroutine()); return true; });               
        }

        internal void AttackShip(ShipController ship)
        {
            if (dying) return;
            AttackingTime(ship.transform.position, () => { ship.ReduceLife(attack); StartCoroutine(IdleCoroutine()); return true; });
        }

        void AttackingTime(Vector3 relativePosition, System.Func<bool> callback)
        {
            if (dying) return;
            attacking = true;
            Motor.Stop();
            if (lastAttackTime >= Time.timeSinceLevelLoad) return;
            animator.SetTrigger("attacking");            

            transform.forward = ObjectManipulation.ForwardNormalized(transform.position, relativePosition);
            lastAttackTime = Time.timeSinceLevelLoad + cooldown;
            callback();
        }

        internal void ReduceLife(float damage)
        {
            life -= damage;
            life = Mathf.Max(life, 0);
            Motor.Stop();

            if (life == 0)
            {
                dying = true;
                animator.SetTrigger("dying");
                if (OnNextHorder != null) OnNextHorder(Motor);
                StartCoroutine(DestroyCoroutine());
            }
            else
            {
                animator.SetTrigger("damage");
                StartCoroutine(ResumeCoroutine());
            }            
        }

        IEnumerator IdleCoroutine()
        {
            yield return new WaitForSeconds(1f);

            animator.SetTrigger("idle");
        }

        IEnumerator ResumeCoroutine()
        {            
            yield return new WaitForSeconds(1f);

            Motor.Resume();            
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(2f);            
            DestroyObject(gameObject);
        }
    }
}