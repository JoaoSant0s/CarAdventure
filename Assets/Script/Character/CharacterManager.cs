using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public delegate void SetCarCamera();
    public static event SetCarCamera OnSetCarCamera;

    [SerializeField]
    Car characterPrefab;
    [SerializeField]
    Transform carDestiny;
        
    Character character;
    Car car;

    private static CharacterManager instance;
    public static CharacterManager Instance {
        get { return instance; }
    }

    public Car CurrentCar {
        get { return car; }
    }

    void Awake () {
        instance = this;                
    }    

    internal void InitializeCharacters(string name) {
        character = new Character(name);        
    }

    internal void InitCar(Vector3 position) {
        ObjectManipulation.RemoveChilds(carDestiny);

        car = Instantiate(characterPrefab, position, Quaternion.identity);
        car.transform.SetParent(carDestiny);
        car.CurrentCharacter = character;        

        if (OnSetCarCamera != null) OnSetCarCamera();
    }
}
