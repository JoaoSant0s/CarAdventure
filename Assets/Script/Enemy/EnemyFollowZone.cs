using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

namespace CarAdventure.Entity.Component {
    public class EnemyFollowZone : MonoBehaviour
    {
        public enum FollowState
        {
            follingCar,
            follingShip
        }
                
        [SerializeField]
        float enemyFollowDistance;               
        [SerializeField]
        FollowState state;

        AttackEnemy enemyController;
        Transform ship;
        Transform car;

        void Awake()
        {
            enemyController = GetComponent<AttackEnemy>();
        }

        void Start()
        {
            Setup();
            FollowShip();
        }

        void Setup()
        {
           
            ship = GameObject.FindGameObjectWithTag("Ship").transform;
            car = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {            
            var currentCarDistance = Vector3.Distance(transform.position, car.position);  

            if(currentCarDistance <= enemyFollowDistance)
            {
                FollowCar();
            }
            else
            {

            }
        }    
        
        void FollowCar()
        {
            state = FollowState.follingCar;            
            enemyController.CheckTarget(car.position);
        }

        void FollowShip()
        {
            state = FollowState.follingShip;            
            enemyController.CheckTarget(ship.position);            
        }
    }
}