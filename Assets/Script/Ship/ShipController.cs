using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [SerializeField]
    float life;
    [SerializeField]
    float energy;

	internal void ReduceLife(float damage)
    {
        life -= damage;
        life = Mathf.Max(life, 0);      
    }
}
