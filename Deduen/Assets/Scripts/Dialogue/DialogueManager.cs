using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private bool dialoguePlaying = false;
    private void OnEnable()
    { 
        GameEventsManager.instance.dialogueEvents.OnEnterDialogue += EnterDialogue;
    }
    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.OnEnterDialogue -= EnterDialogue;

    }
    private void EnterDialogue(string knotName)
    {
        //dont enter dialogue if already playing one
        if (dialoguePlaying)
        {
            return;
        }
        dialoguePlaying = true;

        Debug.Log("Entering dialogue for knot name: " + knotName);
    }

}
