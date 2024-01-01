using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public string[] lines;

    public float textSpeed = 0.1f;

    int index = 0;

    void Start()
    {
        StartDialogue();
    }
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

      
        dialogueText.text += "\n";
        yield return new WaitForSeconds(textSpeed);

        index++; 
        if (index < lines.Length)
        {
            StartCoroutine(WriteLine()); 
        }
    }

}
