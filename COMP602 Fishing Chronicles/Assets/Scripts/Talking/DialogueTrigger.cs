using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);//on collision, print the npc name in the debug fjnornvj
    }

    private void invoke(Action triggerDialogue)
    {
        throw new NotImplementedException();
    }

    

    
}
