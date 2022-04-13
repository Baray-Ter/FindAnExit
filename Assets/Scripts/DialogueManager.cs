using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;
    public bool canClick = true;
    

    public Animator animator;
    // Use this for initialization

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    //click with the continue button
    public void DisplayNextSentence()
    {

        if (canClick == false)
        {
            StopAllCoroutines();

            //string sentence = ??;  the current value of the queue so i can show the text that is currently showing with animation 

            canClick = true;
        }
        else if (canClick == true)
        {
            canClick = false;


            if (sentences.Count == 0)
            {

                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();

            StartCoroutine(TypeSentence(sentence));
        }

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
        }
        canClick = true;
    }

    void EndDialogue()
    {
        Debug.Log("End Of conversation");
        animator.SetBool("IsOpen", false);
    }
}