using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    [Header("Dialogs Components")]

    [SerializeField]
    DialogsModule dialogsModule;
    [SerializeField]
    Transform dialogContent;
    [SerializeField]
    Text dialogText;

    [Header("Dialogs Configs")]

    [SerializeField]
    float delay = 0.1f;
    
    Speaks currentSpeaks;
    Coroutine currentCoroutine;
    bool startedDialog;
    int countTextDialog;
    

    void Start() {
        startedDialog = false;
        countTextDialog = 0;        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            if (!startedDialog) {
                NextText();
            } else {
                CompleteText();
            }
            
        }
    }

    void NextText() {
        if (startedDialog) return;
        if (countTextDialog >= dialogsModule.GetDialogs().Count) return;

        startedDialog = true;

        currentSpeaks = dialogsModule.GetDialog(countTextDialog);
        currentCoroutine = StartCoroutine(ShowText());

        countTextDialog++;
    }

    void CompleteText() {
        StopCoroutine(currentCoroutine);
        startedDialog = false;        
        dialogText.text = currentSpeaks.SpeakString();
    }

    IEnumerator ShowText() {
        var currentText = "";
        for (int i = 0; i <= currentSpeaks.SpeakString().Length; i++) {
            currentText = currentSpeaks.SpeakString().Substring(0, i);

            if(startedDialog) dialogText.text = currentText;
            if (currentText == currentSpeaks.SpeakString()) startedDialog = false;           
            
            yield return new WaitForSeconds(delay);
        }
    }




}
