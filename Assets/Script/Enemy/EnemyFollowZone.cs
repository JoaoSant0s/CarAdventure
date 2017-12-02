using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

namespace CarAdventure.Entity.Component {
    public class EnemyFollowZone : MonoBehaviour
    {
        public enum FollowState
        {
            FollingCar,
            FollingShip
        }
                
        [SerializeField]
        float enemyFollowDistance;               
        [SerializeField]
        FollowState state;
        [SerializeField]
        AttackEnemy enemyController;

        Transform ship;
        Transform car;        

        void Start()
        {
            Setup();
            FollowShip();
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
                if(state == FollowState.FollingCar) FollowShip();
            }
        }    

        void Setup()
        {
           
            ship = GameObject.FindGameObjectWithTag("Ship").transform;
            car = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        void FollowCar()
        {
            state = FollowState.FollingCar;            
            enemyController.CheckTarget(car.position);
        }

        void FollowShip()
        {
            state = FollowState.FollingShip;            
            enemyController.CheckTarget(ship.position);            
        }
    }
}