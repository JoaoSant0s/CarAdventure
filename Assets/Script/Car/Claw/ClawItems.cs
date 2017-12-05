using System.Collections.Generic;
using UnityEngine;

namespace CarAdventure.Entity.Component {

    public class ClawItems : MonoBehaviour {

        public delegate void SelectedItem(ItemList.ItemType itemId);
        public static event SelectedItem OnSelectedItem;

        public delegate void UpdateItems(List<ItemList.ItemType> list);
        public static event UpdateItems OnUpdateItems;

        [SerializeField]
        int selectedItem = 0;
        [SerializeField]
        List<ItemList.ItemType> items = new List<ItemList.ItemType>();
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
        LineRenderer line;
        Ray ray;

        Transform terreno;

        void Start()
        {
            FixedArmor.OnRemoveArmor += RemoveArmor;

            lastAttackTime = 0f;
            line = GetComponent<LineRenderer>();  
            terreno = GameObject.FindGameObjectWithTag("Terrain").transform;
        }

        void OnDestroy()
        {
            FixedArmor.OnRemoveArmor -= RemoveArmor;
        }
        
        void Update()
        {            
            ray = new Ray(targetDirection.position, targetDirection.forward);
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, ray.GetPoint(10f));            

            UseSelectedItem();
        }

        void RemoveArmor()
        {
            currentFixedArmors--;
            currentFixedArmors = Mathf.Max(0, currentFixedArmors);
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
                    Instantiate(armorPrefab, ( new Vector3(transform.position.x, armorPrefab.transform.position.y, transform.position.z) ), Quaternion.identity, terreno);    
                }            
            }
        }

        void CreateBullet()
        {
            var currentBullet = Instantiate(bullet, targetDirection.position, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody>().AddForce(targetDirection.forward.normalized * constanteForce, ForceMode.Force);
        }              

        void SelectItem() {
            if (OnSelectedItem != null) OnSelectedItem(items[selectedItem]);            
        }

    }
}
