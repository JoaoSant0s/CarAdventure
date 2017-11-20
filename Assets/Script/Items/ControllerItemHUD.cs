
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Controller.UI { 

    public class ControllerItemHUD : MonoBehaviour {
        
        [SerializeField]
        ItemList itemList;

        [SerializeField]
        Transform content;

        List<ItemHUD> itens;
        
	    void Awake () {
            ClawItems.OnSelectedItem += SelectedItem;
            ClawItems.OnUpdateItems += UpdateItems;

            itens = new List<ItemHUD>();
        }

        void SelectedItem(ItemList.ItemType itemId) {
            foreach (var item in itens) {
                item.SetSelection(item.Type == itemId);
            }
        }

        void UpdateItems(List<ItemList.ItemType> list) {
            foreach (var type in list) {
                var itemHud = Instantiate(itemList.GetItemHUDPrefab(type));            
                itemHud.transform.SetParent(content);
                itens.Add(itemHud);
            }
        }

    }

}