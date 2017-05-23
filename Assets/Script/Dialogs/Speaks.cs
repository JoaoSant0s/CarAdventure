using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Speaks {

    [SerializeField]
    string speakerName;

    [SerializeField]
    [Multiline]
    string speakString;

    [SerializeField]
    string audioType;

    internal string SpeakerName() {
        return speakerName;
    }

    internal string SpeakString() {
        return speakString;
    }

    internal string AudioType() {
        return audioType;
    }

}
