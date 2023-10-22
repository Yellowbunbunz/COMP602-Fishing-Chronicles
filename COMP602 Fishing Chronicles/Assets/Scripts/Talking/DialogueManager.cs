using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    void Start()
    {
        UpdateDialogue();
    }

    void Update()
    {
        UpdateDialogue();
    }
    private void UpdateDialogue()
    {
        if(NPCInteraction.instance.isPlayerNearby())
        {
            dialogueText.text = "peepee";
            Debug.Log("penis B)");
        }
    }

}
