using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    [SerializeField]
    Character characterPrefab;
    [SerializeField]
    int numberCharacters;

    List<Character> currentCharacters;

    Dictionary<Character, Character> opa;
    
    private static CharacterManager instance;
    public static CharacterManager Instance {
        get { return instance; }
    }

	void Awake () {
        instance = this;
    }

    public List<Character> InitCharacters(List<Vector3> positions) {
        currentCharacters = new List<Character>();

        for (int i = 0; i < numberCharacters; i++) {
            var character = Instantiate(characterPrefab, positions[i], Quaternion.identity);
            currentCharacters.Add(character);
        }
                
        return currentCharacters;
    }
}
