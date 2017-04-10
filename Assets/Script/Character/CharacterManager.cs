using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    [SerializeField]
    Character characterPrefab;

    List<Character> currentCharacters;
    
    private static CharacterManager instance;
    public static CharacterManager Instance {
        get { return instance; }
    }

	void Awake () {
        instance = this;
    }

    public List<Character> InitCharacters(List<Vector3> positions) {
        currentCharacters = new List<Character>();
        foreach (var pos in positions) {
            var character = Instantiate(characterPrefab, pos, Quaternion.identity);
            currentCharacters.Add(character);
        }        
        return currentCharacters;
    }
}
