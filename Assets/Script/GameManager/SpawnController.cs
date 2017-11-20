using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Controller.Manager 
{ 
	public class SpawnController : MonoBehaviour 
	{
        [SerializeField]
        EnemyMotor[] enemiesPrefab;
		[SerializeField]	
		Transform [] spawnEnemiesPosition;                
        [SerializeField]
        float waitSpawnTime;
		
		void Start()
		{
            StartCoroutine(SpawnEnemies());
		}	

        IEnumerator SpawnEnemies()
        {
            for (int i = 0; i < spawnEnemiesPosition.Length; i++)
            {
                var position = spawnEnemiesPosition[i].position;
                var colliderElement = spawnEnemiesPosition[i].GetComponent<BoxCollider>();
                var offsetWidth = colliderElement.size.x / 2;
                var offsetHeight = colliderElement.size.z / 2;

                for (int j = 0; j < enemiesPrefab.Length; j++)
                {
                    var x = Random.Range(-offsetWidth, offsetWidth);
                    var z = Random.Range(-offsetHeight, offsetHeight);                    
                    var instance = Instantiate(enemiesPrefab[j], spawnEnemiesPosition[i]);
                    instance.transform.localPosition = new Vector3(x, 0, z);

                    yield return new WaitForSeconds(waitSpawnTime);
                }
            }
        }
	}
}
