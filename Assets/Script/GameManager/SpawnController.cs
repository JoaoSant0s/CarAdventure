using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity.Component;
using CarAdventure.Entity;

namespace CarAdventure.Controller.Manager 
{ 
	public class SpawnController : MonoBehaviour 
	{
        public delegate void HorderCounter(int currenTime);
        public static event HorderCounter OnHorderTimeCounter;

        [SerializeField]
        EnemyMotor[] enemiesPrefab;
		[SerializeField]	
		Transform [] spawnEnemiesPosition;                
        [SerializeField]
        float waitSpawnTime;

        [SerializeField]
        [Range(1f, 5f)]
        int minEnemies;
        [SerializeField]
        [Range(1f, 10f)]
        int maxEnemies;

        [SerializeField]
        int startSpawnTime;
        [SerializeField]
        int nextSpawnTime;

        [SerializeField]
        Transform miniMap;
        [SerializeField]
        FollowCar followPrefab;        
        
        List<EnemyMotor> enemies;
        List<FollowCar> followEnemies;

        int currentNumberEnemies;

        void Awake()
        {
            AttackEnemy.OnNextHorder += ReduceCount;
        }

        void OnDestroy()
        {
            AttackEnemy.OnNextHorder -= ReduceCount;
        }        

        internal void StartSpawn()
        {
            StartCoroutine(SpawnEnemies(startSpawnTime));
        }

        IEnumerator SpawnEnemies(int seconds)
        {               
            for (int i = seconds - 1; i >= 0; i--)
            {
                if (OnHorderTimeCounter != null) OnHorderTimeCounter(i);
                yield return new WaitForSeconds(1f);
                              
            }
            
            enemies = new List<EnemyMotor>();
            followEnemies = new List<FollowCar>();
            
            var numberEnemies = Random.Range(minEnemies, maxEnemies);
            currentNumberEnemies = numberEnemies;

            for (int j = 0; j < numberEnemies; j++)
            {
                var spawnGateNumber = Random.Range(0, spawnEnemiesPosition.Length);                
                                  
                var enemy = Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], spawnEnemiesPosition[spawnGateNumber]);
                enemy.transform.localPosition = GetPosition(spawnGateNumber);

                var follow = Instantiate(followPrefab, miniMap);

                enemies.Add(enemy);
                follow.TargetUnity = enemy.transform;
                followEnemies.Add(follow);

                yield return new WaitForSeconds(waitSpawnTime);
            }
        }

        Vector3 GetPosition(int gateNumber)
        {
            var colliderElement = spawnEnemiesPosition[gateNumber].GetComponent<BoxCollider>();
            var offsetWidth = colliderElement.size.x / 2;
            var offsetHeight = colliderElement.size.z / 2;

            var x = Random.Range(-offsetWidth, offsetWidth);
            var z = Random.Range(-offsetHeight, offsetHeight); 
            return new Vector3(x, 0, z);
        }

        void ReduceCount(EnemyMotor motor)
        {
            currentNumberEnemies--;
            currentNumberEnemies = Mathf.Max(0, currentNumberEnemies);
            var removedEnemy = enemies.IndexOf(motor);

            enemies.Remove(motor);
            DestroyObject(followEnemies[removedEnemy].gameObject);
            followEnemies.RemoveAt(removedEnemy);
            if (currentNumberEnemies == 0) StartCoroutine(SpawnEnemies(nextSpawnTime));
        }

        internal void RemoveAllEnemeies()
        {
            for(var i = 0; i < enemies.Count; i++)
            {    
                DestroyObject(enemies[i].gameObject);
                DestroyObject(followEnemies[i].gameObject);                
            }   
            enemies.Clear();
            followEnemies.Clear();      
        }

    }
}
