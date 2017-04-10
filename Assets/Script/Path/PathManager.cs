using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

    [SerializeField]
    int pathIndex;
    [SerializeField]
    TrackCollection trackCollection;

    PathController currentTrack;
    Dictionary<Character, List<SavePoint>> characterSavePoinst;

    void Awake() {
        SavePath.OnSavePoint += SavePoint;
    }

    void OnDestroy() {
        SavePath.OnSavePoint -= SavePoint;
    }

    void Start() {
        characterSavePoinst = new Dictionary<Character, List<SavePoint>>();
        currentTrack = Instantiate (trackCollection.Paths[pathIndex], new Vector3(0, 2,0), new Quaternion(0, 1, 0, 1));

        var characters = CharacterManager.Instance.InitCharacters(currentTrack.InitialCharacterPosition);
        
        foreach (var character in characters) {        
            characterSavePoinst[character] = new List<SavePoint>(currentTrack.SavePoints);
        }       
    }

    void SavePoint(Character character, int id, bool verify) {        
        var savePoint = characterSavePoinst[character].Find(x => x.Index == id);
        if (savePoint == null) return;
                                                
        savePoint.Verify = verify;        
    }

    bool CheckCharacterCompleteTurn(Character character) {
        var points = characterSavePoinst[character];

        return points.FindAll(x => x.Verify == false).Count == 0;
    }


}
