using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public delegate void ActivePortalCam();
    public static event ActivePortalCam OnActivePortalCam;

    [SerializeField]
    GameObject prefabBlack;
    [SerializeField]
    float spawnTime = 2f;
    [SerializeField]
    float camTime = 1.5f;
    [SerializeField]
    Transform finalPosition;

    List<Goal> goals;

    bool complete;
    void Awake() {
        complete = false;
    }

    void Update() {
        if (goals == null) { goals = new List<Goal>(GameObject.FindObjectsOfType<Goal>()); }
    }

    void OnTriggerEnter(Collider collider) {
        var claw = collider.gameObject.GetComponentInParent<Claw>();
        if (claw == null) return;

        var goal = claw.ReleaseGoal();
        if (goal == null) return;

        goal.transform.SetParent(transform);
        goal.Active = true;

        CheckAllActives();
    }

    void CheckAllActives() {
        if (complete) return;

        var result = true;
        goals.ForEach(goal => result &= (goal.Active));        

        if (!result) return;
        complete = true;

        ActivePortal();

    }

    void ActivePortal() {
        if (OnActivePortalCam != null) OnActivePortalCam();
        StartCoroutine(ActivePortalCoroutine());
    }

    IEnumerator ActivePortalCoroutine() {
        yield return new WaitForSeconds(camTime);
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

        var finalBlock = Instantiate(prefabBlack, transform.position, Quaternion.identity);

        finalBlock.transform.SetParent(transform);
        finalBlock.transform.position = finalPosition.position;
        finalBlock.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        Time.timeScale = 0f;
    }    

}
