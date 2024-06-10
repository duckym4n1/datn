using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public NPCDialog dialogueScript;
    private bool playerDetected;
    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we trigger player enable playerdetected and show indicator
        if(collision.tag == "Player")
        {
            playerDetected = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;

        }
    }

    //While detected if we interact start the dialogue
    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}
