using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NPCDialog : MonoBehaviour
{
    //Window
    public GameObject window;
    //Text component
    public TMP_Text dialogueText;
    //DialogueList
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started bool
    private bool started;
    //Wait for next boolean
    private bool waitForNext;
    private void Awake()
    {
        ToggleWindow(false);
    }
    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if(started)
            return;
        started= true;
        //Show the window
        ToggleWindow(true);
        //Start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //Start index at 0
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Writing());
    }
    //End Dialogue
    public void EndDialogue() 
    {
        //Hide the window
        ToggleWindow(false);
    }
    //Writing logic
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the char index
        charIndex++;
        //Make sure you have reached the end of the sentence
        if(charIndex< currentDialogue.Length)
        {
            //Wait x sec 4 next char
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else
        {
            //end the sentences
            waitForNext = true;
        }
        
    }

    private void Update()
    {
        if (!started)
            return;
        if(waitForNext&& Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            if(index<dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                //End dialog
                EndDialogue();
            }
        }
    }
}
