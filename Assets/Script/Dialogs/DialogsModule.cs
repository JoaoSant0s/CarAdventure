using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsModule : ScriptableObject {

    [SerializeField]
    List<Speaks> dialogs;

    internal List<Speaks> GetDialogs() {
        return dialogs;
    }

    internal Speaks GetDialog(int index) {
        return dialogs[index];
    }
	
}
