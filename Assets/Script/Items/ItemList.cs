
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Environment;
using CarAdventure.Controller.UI;

namespace CarAdventure.Entity.Component {

    public class ItemList : ScriptableObject {
        
        public enum ItemType {
             hook = 0,
             gun = 1,
             net = 2
        }

        [SerializeField]
        List<ItemDictionary> list;
    
        public ItemHUD GetItemHUDPrefab(ItemType type) {
            return list.Find(x => x.GetType() == type).GetItemHUDPrefab();
        }

        public Item GetItemObjectPrefab(ItemType type) {
            return list.Find(x => x.GetType() == type).GetItemObjectPrefab();
        }

    }

    [System.Serializable]
    public class ItemDictionary {

        [SerializeField]
        ItemList.ItemType type;
        [SerializeField]
        ItemHUD prefabHUD;
        [SerializeField]
        Item prefabObject;

        public ItemList.ItemType GetType() {
            return type;
        }
        public ItemHUD GetItemHUDPrefab() {
            return prefabHUD;
        }

        public Item GetItemObjectPrefab() {
            return prefabObject;
        }
    }

}