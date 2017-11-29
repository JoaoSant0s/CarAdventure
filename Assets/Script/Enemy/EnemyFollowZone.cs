using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

public class EnemyFollowZone : MonoBehaviour {

    public enum FollowState {
        follingEnemy,
        follingShip
    }

	[SerializeField]
	AttackEnemy enemyController;
	[SerializeField]
	GameObject destiny;

    Transform follingCar;	

    FollowState state;

    internal bool IsFollowing{
		get {return follingCar != null;}
	}

	void Start(){
        state = FollowState.follingShip;
        if (destiny == null) destiny = GameObject.FindGameObjectWithTag("Ship").gameObject;
        FollowShip();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject);
        var auxCar = collider.gameObject.GetComponentInParent<Car>();

        if (auxCar != null)
        {
            follingCar = auxCar.transform;
            state = FollowState.follingEnemy;
        }
        else
        {            
            state = FollowState.follingShip;
        }
        Debug.Log(state);
    }

    void OnTriggerStay(Collider collider) {
        Debug.Log(collider.gameObject);
        //Debug.Log(state);
        if (state == FollowState.follingEnemy)
        {
            enemyController.CheckTarget(follingCar.position, true);            
        }
        else if (state == FollowState.follingShip)
        {
            FollowShip();
        }                   
	}

	void OnTriggerExit(Collider collider) {
        Debug.Log(collider.gameObject);
        var auxCar = collider.gameObject.GetComponentInParent<Car>();

        enemyController.NotAttack();

        if (auxCar != null)
        {
            follingCar = null;
            state = FollowState.follingShip;
            FollowShip();
        }
        //Debug.Log(state);
    }

    void FollowShip()
    {
        enemyController.CheckTarget(destiny.transform.position, false);
    }
}
