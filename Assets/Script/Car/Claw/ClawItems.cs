
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

        LineRenderer line;
        Ray ray;

        void Start() {
            line = GetComponent<LineRenderer>();
            if (OnUpdateItems != null)
                OnUpdateItems(items);

            SelectItem();
        }
        
        void Update() {

            RaycastHit hit;
            ray = new Ray(targetDirection.position, targetDirection.forward);
            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(targetDirection.position, targetDirection.forward, out hit, 100f)) {
                line.SetPosition(1, hit.point);
            } else {
                line.SetPosition(1, ray.GetPoint(100f));
            }

            MouseSelectItem();

            UseSelectedItem();
        }

        void MouseSelectItem() {
            var previousSelectedItem = selectedItem;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
                if (selectedItem >= items.Count - 1) {
                    selectedItem = 0;
                } else {
                    selectedItem++;
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
                if (selectedItem <= 0) {
                    selectedItem = items.Count - 1;
                } else {
                    selectedItem--;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                selectedItem = 0;
            } else if (Input.GetKeyDown(KeyCode.Alpha2) && items.Count > 1) {
                selectedItem = 1;
            } else if (Input.GetKeyDown(KeyCode.Alpha3) && items.Count > 2) {
                selectedItem = 2;
            }

            if (previousSelectedItem != selectedItem) {
                SelectItem();
            }
        }

        void UseSelectedItem() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                if (Physics.Raycast(targetDirection.position, targetDirection.forward, out hit, 100f)) {
                    Debug.Log(hit.transform.name);
                }
            }
        }

        void SelectItem() {
            if (OnSelectedItem != null)
                OnSelectedItem(items[selectedItem]);
            Debug.Log(selectedItem);
        }

    }
}
