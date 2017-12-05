using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using CarAdventure.Entity;
using CarAdventure.Entity.Component;
using CarAdventure.Controller;

[CustomEditor(typeof(EnemyAttackZone))]
public class EnemyAttackZoneEditor : Editor {

    void OnSceneGUI()
    {   
        EnemyAttackZone eaz = (EnemyAttackZone) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(eaz.transform.position, Vector3.up, Vector3.forward, 360, eaz.ViewRadius);
        Vector3 viewAngleA = eaz.DirFromAngle(-eaz.ViewAngle/2, false);
        Vector3 viewAngleB = eaz.DirFromAngle(eaz.ViewAngle/2, false);

        Handles.DrawLine(eaz.transform.position, eaz.transform.position + viewAngleA * eaz.ViewRadius);
        Handles.DrawLine(eaz.transform.position, eaz.transform.position + viewAngleB * eaz.ViewRadius);

        Handles.color = Color.red;
        foreach(var visibleTarger in eaz.VisibleTargets){
            Handles.DrawLine(eaz.transform.position, visibleTarger.position);
        }
    }
}

namespace CarAdventure.Entity.Component {

    public class EnemyAttackZone : MonoBehaviour
    {        
        [SerializeField]
        float viewRadius;
        [Range(0, 360)]    
        [SerializeField]    
        float viewAngle;
        [SerializeField]
        AttackEnemy enemyController;
        [SerializeField]
        LayerMask targetMask;
        [SerializeField]
        LayerMask obstacleMask;

        List<Transform> visibleTargets = new List<Transform>();

        Car attackedEnemy;

        void Awake()
        {
            attackedEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Car>();
        }

        void Start()
        {
            StartCoroutine("FindVisibleTargestCoroutine", 0.2f);
        }

        public float ViewRadius{
            get{return viewRadius;}
        }

        public float ViewAngle{
            get{return viewAngle;}
        }

        public List<Transform> VisibleTargets{
            get{return visibleTargets;}
        }        

        IEnumerator FindVisibleTargestCoroutine(float delay)
        {
            while(true){
                yield return new WaitForSeconds(delay);
                FindVisibleTargest();
            }
        }

        void FindVisibleTargest()
        {
            visibleTargets.Clear();
            Collider[] targestInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for(int i = 0; i < targestInViewRadius.Length; i++){
                Transform target = targestInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distance = Vector3.Distance(transform.position, target.position);
                    if(!Physics.Raycast(transform.position, dirToTarget, distance, obstacleMask)){
                        visibleTargets.Add(target);
                        Attack(target.gameObject);
                    }
                }
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if(!angleIsGlobal){
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0,  Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        void Attack(GameObject target)
        {            
            if (target.tag == "Ship")
            {
                enemyController.AttackShip(target.GetComponent<ShipController>());
            }else
            {    
                var car = target.GetComponentInParent<Car>();                
                if(car != null) enemyController.Attack(attackedEnemy);
            }
        }
    }
}