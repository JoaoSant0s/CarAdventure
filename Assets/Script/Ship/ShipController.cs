using UnityEngine;
using CarAdventure.Controller.Manager;


namespace CarAdventure.Controller{
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
            if(life == 0)
            {
                life = startLife;
                if (OnReduceShipLife != null) OnReduceShipLife(life, startLife);
                GameManager.Instance.RestartGame();
            }
        }
    }
}