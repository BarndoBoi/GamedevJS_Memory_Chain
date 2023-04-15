using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypedText : MonoBehaviour
{
    [SerializeField]
    float typeTime; //This must elapse before the next character is written
    [SerializeField]
    TMPro.TMP_Text TextComponent; //The target component to write the characters into
    [SerializeField]
    RectTransform textParent; //For hiding and showing the dialogue box

    //This delegate gets called after the user skips the autotyping or it completes normally
    public delegate void OnTypingDone();
    public OnTypingDone onTypingDone; 

    public string TestString; //Only for testing purposes

    string textToWrite;
    private IEnumerator activeCoroutine;

    private void Start()
    { //For testing purposes only right now
        StartTyping(TestString);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine(activeCoroutine);
            TextComponent.text = textToWrite;
            if (onTypingDone != null)
                onTypingDone(); //Call the delegate if they skip the typing
        }
    }

    public void StartTyping(string text)
    {
        //Clear the existing text before we start writing and display the component's parent object
        TextComponent.text = "";
        textToWrite = text;
        activeCoroutine = WriteText();
        StartCoroutine(activeCoroutine);
    }

    private IEnumerator WriteText()
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            TextComponent.text = string.Concat(TextComponent.text, textToWrite[i]);
            yield return new WaitForSeconds(typeTime); //Wait until time has elapsed before writing the next
        }

    }

    private void OnTextFinished()
    {

    }
}
