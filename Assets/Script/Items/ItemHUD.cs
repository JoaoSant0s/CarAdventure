
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Controller.UI{

    public class ItemHUD : MonoBehaviour {

        [SerializeField]
        ItemList.ItemType type;        

        [SerializeField]
        GameObject opacity;
    
        public void SetSelection(bool selection) {
            opacity.SetActive(!selection);
        } 
    
        public ItemList.ItemType Type {
            get {return type;}        
        }   

    }
}