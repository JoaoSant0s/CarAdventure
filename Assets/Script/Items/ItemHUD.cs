using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
