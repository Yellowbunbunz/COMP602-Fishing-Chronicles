using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnTriggerEnter(Collider collision)
    {
        invoke(TriggerDialogue);
    }

    private void invoke(Action triggerDialogue)
    {
        throw new NotImplementedException();
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    
}
