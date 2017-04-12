using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    [SerializeField]
    Car characterPrefab;        

    Dictionary<string, Character> characters;
    Dictionary<Character, Car> cars;

    private static CharacterManager instance;
    public static CharacterManager Instance {
        get { return instance; }
    }

    void Awake () {
        instance = this;
        characters = new Dictionary<string, Character>();
        cars = new Dictionary<Character, Car>();
    }

    internal Dictionary<string, Character>.ValueCollection Characters {
        get { return characters.Values; }
    }

    internal Dictionary<Character, Car>.ValueCollection Cars {
        get { return cars.Values; }
    }

    internal void InitializeCharacters(string[] charactersName) {
        foreach (var name in charactersName) {
            characters[name] = new Character(name);
        }     
    }

    internal void InitCars(List<Vector3> positions) {
        int i = 0;
        foreach (var character in characters.Values) {
            cars[character] = Instantiate(characterPrefab, positions[i], Quaternion.identity);
            cars[character].CurrentCharacter = character;
            i++;
        }                     
    }
}
