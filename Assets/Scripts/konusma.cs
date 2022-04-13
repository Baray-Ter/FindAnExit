using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class konusma : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] DialogueContent;
    private Queue<string> sentences;
    private string talk;
    private int i = 0;
    public TextMeshPro talkBouble;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void onClick()
    {
        if (i < DialogueContent.Length)
        {
            sentences.Enqueue(DialogueContent[i]);
            talk = sentences.Dequeue();
            talkBouble.text = talk;
            i++;
        }
        else
        {
            cleanText();
        }
    }

    private void cleanText(){
        talkBouble.text = "";
        i = 0;
    }
}