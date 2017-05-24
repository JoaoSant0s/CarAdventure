
using System.Collections;
using UnityEngine;
using CarAdventure.Controller.UI;

namespace CarAdventure.Entity { 
    public class Car : MonoBehaviour {

        public delegate void DestroyCar();
        public static event DestroyCar OnDestroyCar;

        public delegate void UpdateHUD(float newLife);
        public static event UpdateHUD OnUpdateHUD;

        [SerializeField]
        float life = 10f;
        [SerializeField]
        Transform bodyGraphic;

        const float maxLife = 10f;
        Character currentCharacter;    
        MeshRenderer bodyBottom;
        MeshRenderer bodyTop;
        Color bodyColor;
        bool imortality;
        
        public Character CurrentCharacter {
            get { return currentCharacter; }
            set { currentCharacter = value; }
        }

        internal float Life {
            get { return life; }
            set { life = value; }
        }    

        internal void IncrementLife(float addiction) {        
            life += addiction;
            life = Mathf.Min(life, maxLife);
        }

        internal void ReduceLife(float damage) {
            if (imortality) return;

            life -= damage;
            life = Mathf.Max(life, 0f);
            if (OnUpdateHUD != null) OnUpdateHUD(life);
            if (life != 0f) {
                StartCoroutine(ImortalityCoroutine());
            }else {
                Destroy();
            }
        }    

        IEnumerator ImortalityCoroutine() {
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

        internal void Destroy() {
            if (OnDestroyCar != null) OnDestroyCar();        

            UIController.Instance.DeadState();
            DestroyObject(gameObject);
        }

        void Awake() {        
            bodyBottom = bodyGraphic.Find("body_bottom").GetComponent<MeshRenderer>();
            bodyTop = bodyGraphic.Find("body_top").GetComponent<MeshRenderer>();
            bodyColor = bodyBottom.material.color;
            currentCharacter = new Character("Player");
            imortality = false;
            if (OnUpdateHUD != null) OnUpdateHUD(life);
        }    

    }
}