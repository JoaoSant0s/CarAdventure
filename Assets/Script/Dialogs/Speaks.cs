
using UnityEngine;

namespace CarAdventure.Entity { 

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

}