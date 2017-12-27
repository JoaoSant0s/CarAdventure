using UnityEngine;
using System.Collections;
using CarAdventure.Entity;

namespace CarAdventure.Controller.Manager {
    public class GameManager : MonoBehaviour {
        
        public delegate void HorderCounter();
        public static event HorderCounter OnShowHorder;

        public delegate void RestartUI();
        public static event RestartUI OnRestartUI;

        [SerializeField]
        Transform spawnPosition;
        [SerializeField]
        Car carPrefab;
        [SerializeField]
        SpawnController spawnController;
        [SerializeField]
        float delayInitSpawn;
        
        [SerializeField]
        AudioSource bgAudio;        

        static GameManager instance;

        public static GameManager Instance{
        	get {        		
        		return instance;
        	}
        }

        void Awake()
        {
        	instance = this;
        }

        void Start()
        {
        	StartCoroutine("ActiveSpawnEnemies");
            bgAudio.Play();
        }

        IEnumerator ActiveSpawnEnemies()
        {        	
        	SpawnCar();
        	yield return new WaitForSeconds(delayInitSpawn);
        	if(OnShowHorder != null) OnShowHorder();
        	spawnController.StartSpawn();
        }

        void SpawnCar() 
        {        
            var currentCar = Instantiate(carPrefab);
            currentCar.transform.position = spawnPosition.position;
            currentCar.transform.SetParent(spawnPosition.parent);
        } 

        internal void RestartGame()
        {            
            if (bgAudio.isPlaying) bgAudio.Stop(); 
            StartCoroutine(RestartGameCoroutine());
        }

        IEnumerator RestartGameCoroutine()
        {
            if(OnRestartUI != null) OnRestartUI();
            
            yield return new WaitForSeconds(1f);
            spawnController.RemoveAllEnemeies();                        
            var car = GameObject.FindObjectOfType<Car>();
            DestroyObject(car.gameObject);                  
            StartCoroutine("ActiveSpawnEnemies"); 
            if(!bgAudio.isPlaying) bgAudio.Play();               
        }
    }
}