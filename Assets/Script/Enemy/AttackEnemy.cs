
using UnityEngine;
using CarAdventure.Common;
using System.Collections;
using CarAdventure.Entity.Component;
using CarAdventure.Controller;

namespace CarAdventure.Entity { 

    public class AttackEnemy : Enemy {
        
        public delegate void NextHorder(EnemyMotor motor);
        public static event NextHorder OnNextHorder;

        float lastAttackTime;  
        bool attacking;      
        bool animationDamage;
        bool dying;
        Animator animator;

        public bool Dying {
            get { return dying; }
        }        

        void Awake()
        {            
            lastAttackTime = 0f;
            animator = GetComponent<Animator>();            
        }        

        internal void CheckTarget(Vector3 targetDestiny)
        {            
            if (dying || attacking) return;            
            Motor.Move(targetDestiny);
        }

        void Update()
        {
            var velocity = Motor.GetVelocity();
            
            if (dying) return;
            if (velocity > 0.05)
            {
                animator.SetTrigger("walking");
            }
            else
            {
                animator.SetTrigger("idle");
            }
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
            if (lastAttackTime >= Time.timeSinceLevelLoad) return;
            attacking = true;
            Motor.Stop();
            animator.SetTrigger("attacking");            

            transform.forward = ObjectManipulation.ForwardNormalized(transform.position, relativePosition);
            lastAttackTime = Time.timeSinceLevelLoad + cooldown;
            callback();
        }

        internal void ReduceLife(float damage)
        {
            if (animationDamage || dying) return;
            animationDamage = true;

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

        internal void ReduceScaleLife(float damage)
        {
            if (dying) return;

            life -= damage;
            life = Mathf.Max(life, 0);            

            if (life == 0)
            {
                dying = true;
                animator.SetTrigger("dying");
                if (OnNextHorder != null) OnNextHorder(Motor);
                StartCoroutine(DestroyCoroutine());
            }
        }

        IEnumerator IdleCoroutine()
        {
            yield return new WaitForSeconds(cooldown);  
            attacking = false;          
            animator.SetTrigger("idle");
        }

        IEnumerator ResumeCoroutine()
        {            
            yield return new WaitForSeconds(1f);
            animationDamage = false;
            Motor.Resume();            
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(2f);            
            DestroyObject(gameObject);
        }
    }
}