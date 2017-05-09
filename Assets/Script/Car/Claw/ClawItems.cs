using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawItems : MonoBehaviour {

    [SerializeField]
    private int selectedItem = 0;

    [SerializeField]
    private Transform targetDirection;

    private List<int> items = new List<int>(new int[] {1, 2, 3});
    private LineRenderer line;
    private Ray ray;

    void Start() {                
        SelectItem();
        line = GetComponent<LineRenderer>();
        
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
            if(selectedItem >= items.Count - 1) {
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
            if(Physics.Raycast(targetDirection.position, targetDirection.forward, out hit, 100f)) {
                Debug.Log(hit.transform.name);
            }

            
        }
    }

    void SelectItem () {
        Debug.Log(selectedItem);
    }                             



}
