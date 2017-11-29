
using System.Collections;
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
        [SerializeField]
        float activeFloatCoolDown;
        [SerializeField]
        float attack;
        [SerializeField]
        GameObject bullet;
        [SerializeField]
        float constanteForce;

        bool activeItem;
        LineRenderer line;
        Ray ray;

        void Start()
        {
            line = GetComponent<LineRenderer>();            
        }
        
        void Update()
        {
            RaycastHit hit;
            ray = new Ray(targetDirection.position, targetDirection.forward);
            line.SetPosition(0, ray.origin);            

            if (Physics.Raycast(targetDirection.position, targetDirection.forward, out hit, 100f)) {
                line.SetPosition(1, hit.point);
            } else {
                line.SetPosition(1, ray.GetPoint(100f));
            }            

            UseSelectedItem();
        }       

        void UseSelectedItem()
        {
            if (activeItem) return;

            if (Input.GetMouseButtonDown(0))
            {

                var currentBullet = Instantiate(bullet, targetDirection.position, Quaternion.identity);
                currentBullet.GetComponent<Rigidbody>().AddForce(targetDirection.forward.normalized * constanteForce, ForceMode.Force);
                //bullet
                //targetDirection.forward
                //activeItem = true;
                //StartCoroutine(ActiveItemCoroutine());
                //line.material.color = Color.green;

                //RaycastHit hit;
                //if (Physics.Raycast(targetDirection.position, targetDirection.forward, out hit, 100f)) {
                //    var enemy = hit.transform.GetComponentInParent<AttackEnemy>();
                //    if (enemy == null) return;
                //    if (enemy.Dying) return;
                //    line.material.color = Color.red;

                //    if (enemy) enemy.ReduceLife(attack);
                //}
            }
        }    
        
        IEnumerator ActiveItemCoroutine()
        {
            yield return new WaitForSeconds(activeFloatCoolDown);
            line.material.color = Color.white;
            activeItem = false;
        }

        void SelectItem() {
            if (OnSelectedItem != null) OnSelectedItem(items[selectedItem]);
            Debug.Log(selectedItem);
        }

    }
}
