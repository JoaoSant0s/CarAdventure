using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionBlock : MonoBehaviour {

    [SerializeField]
    Goal prefabBlack;
    [SerializeField]
    float spawnTime = 2f;

    List<Goal> goals;
    bool isToUpdate;	

    void Awake() {
        isToUpdate = true;
    }

	void Update () {
        UpdatePosition();
    }


    void UpdatePosition() {
        if (!isToUpdate) return;

        if (goals == null) { goals = new List<Goal>(GameObject.FindObjectsOfType<Goal>()); }

        var listVectors = goals.ConvertAll<Vector2>(vector => new Vector2(vector.transform.position.x, vector.transform.position.z));
        var xPosition = 0f;
        var zPosition = 0f;

        listVectors.ForEach(vector => xPosition += vector.x);
        listVectors.ForEach(vector => zPosition += vector.y);
        xPosition = xPosition / goals.Count;
        zPosition = zPosition / goals.Count;       

        transform.position = new Vector3(xPosition, transform.position.y, zPosition);
    }

    void OnTriggerEnter(Collider collider) {        
        var goal = collider.gameObject.GetComponent<Goal>();             
        if (goal == null || goals == null) return;

        goal.Active = true;
        CheckAllActives();
    }

    void OnTriggerExit(Collider collider) {
        var goal = collider.gameObject.GetComponent<Goal>();
        if (goal == null || goals == null) return;

        goal.Active = false;
    }

    void CheckAllActives() {
        var result = true;
        goals.ForEach(goal => result &= goal.Active);        

        if (!result) return;
        isToUpdate = false;

        foreach (var goal in goals) {
            DestroyObject(goal.gameObject);
        }
        goals.Clear();

        GenerateNewCube();        
    }

    void GenerateNewCube() {
        StartCoroutine(GenerateNewCubeCoroutine());
    }

    IEnumerator GenerateNewCubeCoroutine() {
        yield return new WaitForSeconds(spawnTime);
        
        var black = Instantiate(prefabBlack, transform.position, Quaternion.identity);
        black.transform.SetParent(transform.parent);

        DestroyObject(gameObject);
    }

}
