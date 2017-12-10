
using System.Collections;
using UnityEngine;
using CarAdventure.Controller.Manager;

namespace CarAdventure.Entity {
    public class Car : MonoBehaviour {

        public delegate void DestroyCar();
        public static event DestroyCar OnDestroyCar;

        public delegate void DamageLife(float currentLife);
        public static event DamageLife OnDamageLife;

        public delegate void ShowLife(float initLife);
        public static event ShowLife OnShowLife;
        
        [SerializeField]
        float life = 10f;
        [SerializeField]
        Transform bodyGraphic;

        const float maxLife = 10f;        
        MeshRenderer bodyBottom;
        MeshRenderer bodyTop;
        Color bodyColor;
        bool imortality;

        void Awake()
        {                    
            bodyBottom = bodyGraphic.Find("body_bottom").GetComponent<MeshRenderer>();
            bodyTop = bodyGraphic.Find("body_top").GetComponent<MeshRenderer>();
            bodyColor = bodyBottom.material.color;            
            imortality = false;            
        }   

        void Start()
        {
            if(OnShowLife != null) OnShowLife(life);            
        }        

        internal float Life {
            get { return life; }
            set { life = value; }
        }    

        internal void IncrementLife(float addiction)
        {        
            life += addiction;
            life = Mathf.Min(life, maxLife);
        }

        internal void ReduceLife(float damage)
        {
            if (imortality) return;

            life -= damage;
            life = Mathf.Max(life, 0f);
            if (OnDamageLife != null) OnDamageLife(life);
            if (life != 0f) {
                StartCoroutine(ImortalityCoroutine());
            }else {
                Destroy();
            }
        }    
        
        IEnumerator ImortalityCoroutine()
        {
            imortality = true;

            bodyTop.material.color = Color.black;
            bodyBottom.material.color = Color.black;                
            yield return new WaitForSeconds(0.5f);
            bodyTop.material.color = bodyColor;
            bodyBottom.material.color = bodyColor;

            yield return new WaitForSeconds(0.5f);
            bodyTop.material.color = Color.black;
            bodyBottom.material.color = Color.black;

            yield return new WaitForSeconds(0.5f);
            bodyTop.material.color = bodyColor;
            bodyBottom.material.color = bodyColor;

            imortality = false;        
        }

        void Destroy()
        {            
            GameManager.Instance.RestartGame();                           
        }
        
    }
}