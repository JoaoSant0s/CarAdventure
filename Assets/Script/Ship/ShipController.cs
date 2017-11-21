using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public delegate void ReduceShipLife(float currentLife, float initialLife);
    public static event ReduceShipLife OnReduceShipLife;

    [SerializeField]
    float life;
    [SerializeField]
    float energy;

    float startLife;

    private void Start()
    {
        startLife = life;
        if (OnReduceShipLife != null) OnReduceShipLife(life, startLife);
    }
    internal void ReduceLife(float damage)
    {
        life -= damage;
        life = Mathf.Max(life, 0);
        if (OnReduceShipLife != null) OnReduceShipLife(life, startLife);
    }
}
