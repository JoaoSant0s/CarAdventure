using System.Collections.Generic;
using UnityEngine;

namespace CarAdventure.Entity.Component {
    public class ClawItems : MonoBehaviour {

        public delegate void SelectedItem(ItemList.ItemType itemId);
        public static event SelectedItem OnSelectedItem;

        public delegate void UpdateItems(List<ItemList.ItemType> list);
        public static event UpdateItems OnUpdateItems;

        public delegate void ShowArmor(float initCount);
        public static event ShowArmor OnShowArmor;

        public delegate void UpdateArmor(float currentCount);
        public static event UpdateArmor OnUpdateArmor;
                
        [SerializeField]
        Transform targetDirection;   
        [Space]
        [Header("Bullet Settings")]
        [SerializeField]
        Bullet bullet;
        [SerializeField]
        float constanteForce;
        [SerializeField]
        internal float cooldown = 2f;    

        [SerializeField]
        FixedArmor armorPrefab; 
        [SerializeField]
        int maxFixedArmors;

        int currentFixedArmors;   

        float lastAttackTime;
        Transform terreno;

        void Start()
        {
            FixedArmor.OnRemoveArmor += RemoveArmor;

            lastAttackTime = 0f;            
            terreno = GameObject.FindGameObjectWithTag("Terrain").transform;
            if(OnShowArmor != null) OnShowArmor(currentFixedArmors);
        }

        void OnDestroy()
        {
            FixedArmor.OnRemoveArmor -= RemoveArmor;
        }
        
        void Update()
        {
            UseSelectedItem();
        }

        void RemoveArmor()
        {
            currentFixedArmors--;
            currentFixedArmors = Mathf.Max(0, currentFixedArmors);
            if(OnUpdateArmor != null) OnUpdateArmor(currentFixedArmors);
        }       

        void UseSelectedItem()
        {         
            if (Input.GetMouseButtonDown(0))
            {
                if (lastAttackTime >= Time.timeSinceLevelLoad) return;
                lastAttackTime = Time.timeSinceLevelLoad + cooldown;
                CreateBullet();                
            }else if (Input.GetMouseButtonDown(1))
            {
                if(currentFixedArmors < maxFixedArmors){
                    currentFixedArmors++;
                    if(OnUpdateArmor != null) OnUpdateArmor(currentFixedArmors);
                    Instantiate(armorPrefab, ( new Vector3(transform.position.x, armorPrefab.transform.position.y, transform.position.z) ), Quaternion.identity, terreno);    
                }            
            }
        }

        void CreateBullet()
        {
            var currentBullet = Instantiate(bullet, targetDirection.position, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody>().AddForce(targetDirection.forward.normalized * constanteForce, ForceMode.Force);
        }                      
    }
}
